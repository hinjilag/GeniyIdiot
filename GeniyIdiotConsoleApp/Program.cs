using System;
using System.Collections.Generic;
using System.IO;

namespace _12345
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double questionsCount = 0;
            Console.WriteLine("Добро пожаловать в игру гений-идиот! Как к вам обращаться ?");
            string userName = Console.ReadLine();
            while (true)
            {

                Console.WriteLine($"{userName}, выбери действие (введи номер)");
                Console.WriteLine();
                Console.WriteLine("""                   
                    1) играть    
                    2) смотреть результаты     
                    3) вход для админа    
                    0) выйти из игры
                    """);
                string messageMenu = Console.ReadLine();
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
                            Console.WriteLine("Что хочешь сделать?");
                            Console.WriteLine("""
                                1) добавить вопрос
                                2) удалить вопрос
                                3) изменить количество вопросов задаваемых пользователю
                                4) отчистить результаты
                                0) выход из админки
                                """);
                            string actionAdm = Console.ReadLine();
                            if (actionAdm == "0")
                            {
                                break;
                            }
                            if (actionAdm == "1")
                            {
                                AddQuestion();
                            }

                            if (actionAdm == "2") // удалить вопрос
                            {
                                DeleteQuestion();

                            }
                            if (actionAdm == "3")
                            {
                                Console.WriteLine("Сколько вопросов задать пользователю?");
                                questionsCount = Convert.ToInt32(Console.ReadLine());
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
                            }
                            if (actionAdm == "4")
                            {
                                Console.WriteLine();
                                File.WriteAllText("..\\..\\..\\results.txt", "");
                                Console.WriteLine("Результаты успешно отчищены!");
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
                    double questionsCountUser = questionsCount;

                    //начало игры

                    Console.WriteLine($"{userName}, отвечай на вопросы, и узнаешь свой диагноз");



                    bool isYes = YesOrNo("Готов ?");

                    Console.WriteLine();

                    if (isYes == false)
                    {
                        Console.WriteLine();
                    }
                    else //hjndjgfsd
                    {
                        while (true)
                        {
                            // вопросы
                            string[] fileQuestions = File.ReadAllLines("..\\..\\..\\questions.txt");
                            List<string> questions = new List<string>() { };
                            for (int i = 0; i < fileQuestions.Length; i++) // проходимся по строкам
                            {
                                questions.Add(fileQuestions[i]);
                            }


                            // ответы
                            string[] fileAnswers = File.ReadAllLines("..\\..\\..\\answers.txt");
                            List<string> answers = new List<string>() { };
                            for (int i = 0; i < fileAnswers.Length; i++)
                            {
                                answers.Add(fileAnswers[i]);
                            }

                            int сorrectAnswersCount = 0;

                            for (int i = 1; i <= questionsCountUser; i++) // сам тест 
                            {
                                int randomIndex = new Random().Next(0, questions.Count);
                                Console.Write($"{i}) ");
                                Console.WriteLine(questions[randomIndex]);

                                string userAnswer = Console.ReadLine();
                                if (answers[randomIndex] == userAnswer)
                                {
                                    сorrectAnswersCount++;
                                }

                                questions.RemoveAt(randomIndex);
                                answers.RemoveAt(randomIndex);
                            }

                            string diagnosis = DefinitDiagnosis(сorrectAnswersCount, questionsCountUser);
                            Console.WriteLine();

                            Console.WriteLine($"Количество баллов: {сorrectAnswersCount}");
                            Console.WriteLine($"{userName}, твой диагноз: {diagnosis}");
                            SaveResult(userName, сorrectAnswersCount, diagnosis); // сохраняем в файл

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

            string answer = Console.ReadLine().ToLower();

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

                answer = Console.ReadLine();
            }

        }

        static void SaveResult(string userName, int correctAnswerCount, string diagnosis)
        {

            // Формируем строку результата
            string result = $"{userName}#{correctAnswerCount}#{diagnosis}";


            // Записываем строку в файл
            File.AppendAllText("..\\..\\..\\results.txt", result + Environment.NewLine);

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

        static void DeleteQuestion() // удалитиь вопрос
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




    }
}


