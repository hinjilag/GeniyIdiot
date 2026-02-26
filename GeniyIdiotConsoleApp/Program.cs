using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics.X86;

namespace _12345
{

    internal class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User();
            int questionsCount = 3;
            Console.WriteLine("Добро пожаловать в игру гений-идиот! Как к вам обращаться ?");

            user1.Name = Console.ReadLine().Trim();

            while (true)
            {

                Console.WriteLine($"{user1.Name}, выбери действие (введи номер)");
                Console.WriteLine();
                Console.WriteLine("""                   
                    1) играть    
                    2) смотреть результаты     
                    3) вход для админа    
                    0) выйти из игры
                    """);
                string messageMenu = Console.ReadLine().Trim();
                if (messageMenu == "0")
                {
                    return;
                }
                if (messageMenu == "2")
                {
                    SeeResults();
                }

                if (messageMenu == "3") // админка
                {

                    Console.WriteLine("введите пароль");
                    string password = Console.ReadLine();
                    if (password == "123")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Здраствуй, админ!");

                        while (true)
                        {

                            string actionAdm = MenuCheck(user1);
                            if (actionAdm == "0")
                            {
                                break;
                            }
                            if (actionAdm == "1") // добавить вопрос 
                            {
                                AddQuestion();
                            }

                            if (actionAdm == "2") // удалить вопрос
                            {
                                DeleteQuestion();

                            }
                            if (actionAdm == "3") // количество задаваемых вопросов
                            {
                                questionsCount = QuestionCountAsk();
                            }
                            if (actionAdm == "4") // очистить результаты
                            {
                                ResultsDelete();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("пароль неверный!");
                    }
                }
                if (messageMenu == "1")
                {
                    // сколько вопросов будут выданы пользователю
                    int questionsCountUser = questionsCount;

                    //начало игры

                    Console.WriteLine($"{user1.Name}, отвечай на вопросы, и узнаешь свой диагноз");

                    bool isYes = YesOrNo("Готов ?");

                    Console.WriteLine();

                    if (isYes == false)
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        while (true)
                        {
                            
                            QuestionsStorage questionsStorage = new QuestionsStorage();

                            // задаем вопросы и получаем количество правильных ответов
                            user1.CorrectAnswersCount = questionsStorage.AskQuestions(user1, (int)questionsCountUser);

                            user1.Diagnoz = DefinitDiagnosis(user1.CorrectAnswersCount, questionsCountUser);
                            Console.WriteLine();

                            Console.WriteLine($"Количество баллов: {user1.CorrectAnswersCount}");
                            Console.WriteLine($"{user1.Name}, твой диагноз: {user1.Diagnoz}");
                            UserStorage userStorage = new UserStorage();

                            userStorage.SaveRecord(user1); // сохраняем в файл

                            Console.WriteLine();

                            isYes = YesOrNo("Сыграем еще раз?");
                            if (isYes == false)
                            {
                                Console.WriteLine("джабах ут");
                                Console.WriteLine();
                                break;
                            }
                        }
                    }
                }
            }
        }

        static string DefinitDiagnosis(int сorrectAnswersCount, double questionsCount)
        {

            double range = questionsCount / 6;
            string diagnoz = "";
            if (сorrectAnswersCount < range)
                diagnoz = "бедолага";
            else if (сorrectAnswersCount < 2 * range)
                diagnoz = "дурак";
            else if (сorrectAnswersCount < 3 * range)
                diagnoz = "дурик";
            else if (сorrectAnswersCount < 4 * range)
                diagnoz = "жить будешь";
            else if (сorrectAnswersCount < 5 * range)
                diagnoz = "тип";
            else
                diagnoz = "тынг тип!!!";
            return diagnoz;
        }

        static bool YesOrNo(string text)
        {
            Console.WriteLine(text);

            string answer = Console.ReadLine().ToLower().Trim();

            while (true)
            {
                if (answer == "да")
                {
                    return true;
                }

                if (answer == "нет")
                {
                    return false;
                }
                Console.WriteLine("Такого варианта нет. Введи да или нет!");

                answer = Console.ReadLine().ToLower().Trim();
            }

        }

       

        // 2) смотреть результаты 
        static void SeeResults()
        {
            Console.WriteLine("пользователь    К.В.О.   диагноз");
            string[] fileData = File.ReadAllLines("..\\..\\..\\results.txt");

            for (int i = 0; i < fileData.Length; i++) // fileData.Length = количество строк в файле
            {
                string resultsLine = fileData[i];
                string[] data = resultsLine.Split('#');
                Console.WriteLine($"{data[0]} \t\t{data[1]} \t {data[2]}");

            }
            Console.WriteLine();
        }

        static void AddQuestion() // добавить вопрос
        {
            Console.WriteLine("Напиши вопрос который хочешь добавить.");
            Console.WriteLine("Для отмены нажми  0");
            string addQuestion = Console.ReadLine().Trim();
            if (addQuestion == "0")
            {
                return;
            }
            Console.WriteLine();
            File.AppendAllText("..\\..\\..\\questions.txt", addQuestion + Environment.NewLine);
            Console.WriteLine("Напиши ответ на этот вопрос");
            string addAnswer = Console.ReadLine().Trim();
            File.AppendAllText("..\\..\\..\\answers.txt", addAnswer + Environment.NewLine);
            Console.WriteLine();
            Console.WriteLine("Вопрос успешно добавлен!");
        }

        static void DeleteQuestion() // удалить вопрос
        {
            Console.WriteLine("Напиши номер вопроса которого хочешь удалить");
            Console.WriteLine();

            string[] fileQuestions = File.ReadAllLines("..\\..\\..\\questions.txt");
            List<string> questions = new List<string>() { };
            for (int i = 0; i < fileQuestions.Length; i++) // проходимся по строкам
            {
                questions.Add(fileQuestions[i]);
            }

            string[] fileAnswers = File.ReadAllLines("..\\..\\..\\answers.txt");
            List<string> answers = new List<string>() { };
            for (int i = 0; i < fileAnswers.Length; i++) // проходимся по строкам
            {
                answers.Add(fileAnswers[i]);
            }


            for (int i = 1; i <= fileQuestions.Length; i++) // выводим вопросы чтоб тип выбрал
            {
                Console.Write($"{i}) ");
                Console.WriteLine(fileQuestions[i - 1]);
            }

            string deleteQuestionStr = Console.ReadLine();

            while (!double.TryParse(deleteQuestionStr, out _))
            {
                Console.WriteLine();
                Console.WriteLine("Введи число!");
                Console.WriteLine();
                deleteQuestionStr = Console.ReadLine();
            }
            int deleteQuestion = Convert.ToInt32(deleteQuestionStr);
            while (deleteQuestion <= 0 || deleteQuestion > questions.Count)
            {
                Console.WriteLine("Вопроса под таким номером нет! Введи номер вопроса из выданных");
                deleteQuestion = Convert.ToInt32(Console.ReadLine());
            }
            questions.RemoveAt(deleteQuestion - 1);
            answers.RemoveAt(deleteQuestion - 1);
            File.WriteAllLines("..\\..\\..\\questions.txt", questions);
            File.WriteAllLines("..\\..\\..\\answers.txt", answers);
            Console.WriteLine();
            Console.WriteLine("Вопрос успешно удален!");
            Console.WriteLine();

        }
        static string MenuCheck(User user)
        {
            User user1 = new User();
            Console.WriteLine($"{user1.Name}, выбери действие (введи номер)");
            Console.WriteLine();
            Console.WriteLine("""                   
                    1) играть    
                    2) смотреть результаты     
                    3) вход для админа    
                    0) выйти из игры
                    """);
            string actionAdm = Console.ReadLine().Trim();
            return actionAdm;
        }
        static int QuestionCountAsk()
        {
            Console.WriteLine("Сколько вопросов задать пользователю?");
            int questionsCount = Convert.ToInt32(Console.ReadLine());
            string[] fileQuestions = File.ReadAllLines("..\\..\\..\\questions.txt");
            List<string> questions = new List<string>() { };
            for (int i = 0; i < fileQuestions.Length; i++) // проходимся по строкам
            {
                questions.Add(fileQuestions[i]);
            }
            while (questionsCount <= 0 || questionsCount > questions.Count)
            {
                Console.WriteLine($"Столько вопросов нет! Введи число от 1 до {questions.Count}");
                questionsCount = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine();
            Console.WriteLine($"Количество вопросов, которые будут заданы пользователю: {questionsCount}");
            Console.WriteLine();
            return questionsCount;
        }
        static void ResultsDelete()
        {
            Console.WriteLine();
            File.WriteAllText("..\\..\\..\\results.txt", "");
            Console.WriteLine("Результаты успешно отчищены!");
        }
    }
}