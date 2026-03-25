using System;
using System.Collections.Generic;
using System.IO;

namespace _12345
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserMy user1 = new UserMy();
            int questionsCount = 3;

            Console.WriteLine("Добро пожаловать в игру гений-идиот! Как к вам обращаться?");
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
                else if (messageMenu == "2")
                {
                    SeeResults();
                }
                else if (messageMenu == "3") // админка
                {
                    Console.WriteLine("введите пароль");
                    string password = Console.ReadLine();

                    if (password == "123")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Здравствуй, админ!");

                        while (true)
                        {
                            Console.WriteLine("Выберите действие:");
                            Console.WriteLine("1) Добавить вопрос");
                            Console.WriteLine("2) Удалить вопрос");
                            Console.WriteLine("3) Изменить количество вопросов");
                            Console.WriteLine("4) Очистить результаты");
                            Console.WriteLine("0) Выйти из админки");

                            string actionAdm = Console.ReadLine().Trim();

                            if (actionAdm == "0")
                            {
                                break;
                            }
                            else if (actionAdm == "1") // добавить вопрос 
                            {
                                AddQuestion();
                            }
                            else if (actionAdm == "2") // удалить вопрос
                            {
                                DeleteQuestion();
                            }
                            else if (actionAdm == "3") // количество задаваемых вопросов
                            {
                                questionsCount = QuestionCountAsk();
                            }
                            else if (actionAdm == "4") // очистить результаты
                            {
                                ResultsDelete();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Пароль неверный!");
                    }
                }
                else if (messageMenu == "1")
                {
                    
                    PlayGame(user1, questionsCount); // спрашивай!!!
                }
            }
        }

        
        static void PlayGame(UserMy user, int questionsCount)
        {
            Console.WriteLine($"{user.Name}, отвечай на вопросы и узнаешь свой диагноз");

            bool isReady = YesOrNo("Готов?");

            if (!isReady)
            {
                Console.WriteLine("А че пришел тогда");
                return;
            }

            while (true)
            {
                // Получаем случайные вопросы
                List<Question> randomQuestions = QuestionsStorage.GetRandomQuestions(questionsCount);

                if (randomQuestions.Count == 0)
                {
                    Console.WriteLine("Вопросов в базе данных нет. Обратитесь к хынджылагу");
                    return;
                }

                
                List<string> userAnswers = new List<string>(); // тут хранятся ответы юзера

                Console.WriteLine("Поехали!");
                Console.WriteLine();

                // задаем вопросы, записываем ответы 
                for (int i = 0; i < randomQuestions.Count; i++)
                {
                    Console.WriteLine($"Вопрос {i + 1} из {randomQuestions.Count}:");
                    Console.WriteLine(randomQuestions[i].Text);
                    Console.Write("Ваш ответ: ");

                    string userAnswer = Console.ReadLine();
                    userAnswers.Add(userAnswer);
                    Console.WriteLine();
                }

                
                int correctAnswers = QuestionsStorage.AskQuestions(randomQuestions, userAnswers);

                // создаем нового типа для сохранения результатов 
                UserMy resultUser = new UserMy
                {
                    Name = user.Name,
                    CorrectAnswersCount = correctAnswers,
                    Diagnoz = DefinitDiagnosis(correctAnswers, questionsCount)
                };

                // Выводим результаты
                Console.WriteLine("-------- Результаты теста --------");
                Console.WriteLine($"Количество правильных ответов: {correctAnswers} из {questionsCount}");
                Console.WriteLine($"{user.Name}, ваш диагноз: {resultUser.Diagnoz}!");

                
                UserStorage userStorage = new UserStorage();
                userStorage.SaveToFile(resultUser);

                Console.WriteLine("Результаты сохранены!");
                Console.WriteLine();

                
                bool playAgain = YesOrNo("Сыграем еще раз?");

                if (!playAgain)
                {
                    Console.WriteLine("джабахут тогда");
                    Console.WriteLine();
                    break;
                }

                Console.Clear();
            }
        }

        static string DefinitDiagnosis(int correctAnswersCount, int questionsCount)
        {
            double range = questionsCount / 6.0;

            if (correctAnswersCount < range)
                return "бедолага";
            else if (correctAnswersCount < 2 * range)
                return "дурак";
            else if (correctAnswersCount < 3 * range)
                return "дурик";
            else if (correctAnswersCount < 4 * range)
                return "жить будешь";
            else if (correctAnswersCount < 5 * range)
                return "тип";
            else
                return "тынг тип!!!";
        }

        static bool YesOrNo(string text)
        {
            while (true)
            {
                Console.Write($"{text} (да/нет): ");
                string answer = Console.ReadLine().ToLower().Trim();

                if (answer == "да"  || answer == "yes" )
                {
                    return true;
                }
                else if (answer == "нет"  || answer == "no" )
                {
                    return false;
                }

                Console.WriteLine("Такого варианта нет. Введи да или нет!");
            }
        }

        // 2) смотреть результаты 
        static void SeeResults()
        {
            Console.WriteLine("пользователь    К.П.О.   диагноз");
            Console.WriteLine();
            var userStorage = new UserStorage();
            var results = userStorage.GetAll();

            foreach (var user in results)
            {
                Console.WriteLine($"{user.Name}\t{user.CorrectAnswersCount}\t{user.Diagnoz}");
            }
            Console.WriteLine();

        }

        static void AddQuestion() // добавить вопрос
        {
            Console.WriteLine("Напиши вопрос, который хочешь добавить");
            Console.WriteLine("Для отмены нажми 0");
            string addQuestion = Console.ReadLine().Trim();

            if (addQuestion == "0")
            {
                return;
            }

            Console.WriteLine("Напиши ответ на этот вопрос");
            string addAnswer = Console.ReadLine().Trim();

            FileStorage.AppendAllText(addQuestion, addAnswer);

            Console.WriteLine("Вопрос успешно добавлен!");
        }

        static void DeleteQuestion() // удалить вопрос
        {
            string[] fileQuestions = FileStorage.ReadAllLines("questions");

            if (fileQuestions.Length == 0)
            {
                Console.WriteLine("Нет вопросов для удаления");
                return;
            }

            Console.WriteLine("Выбери номер вопроса, который хочешь удалить:");

            for (int i = 0; i < fileQuestions.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {fileQuestions[i]}");
            }

            string input = Console.ReadLine();

            if (!int.TryParse(input, out int deleteQuestion) ||
                deleteQuestion < 1 ||
                deleteQuestion > fileQuestions.Length)
            {
                Console.WriteLine("такого вопроса нет");
                return;
            }

            List<string> questions = new List<string>(FileStorage.ReadAllLines("questions"));
            List<string> answers = new List<string>(FileStorage.ReadAllLines("answers"));

            questions.RemoveAt(deleteQuestion - 1);
            answers.RemoveAt(deleteQuestion - 1);

            FileStorage.WriteAllLines(questions, answers);
            

            Console.WriteLine("Вопрос успешно удален!");
        }

        static int QuestionCountAsk()
        {
            string[] fileQuestions = FileStorage.ReadAllLines("questions");

            Console.WriteLine($"Сколько вопросов задать пользователю? (максимум {fileQuestions.Length})");

            int questionsCount;
            while (!int.TryParse(Console.ReadLine(), out questionsCount) ||
                   questionsCount <= 0 ||
                   questionsCount > fileQuestions.Length)
            {
                Console.WriteLine($"Столько вопросов нет! Введи число от 1 до {fileQuestions.Length}");
            }

            Console.WriteLine($"Количество вопросов, которые будут заданы пользователю: {questionsCount}");
            return questionsCount;
        }

        static void ResultsDelete()
        {
            FileStorage.ClearResults();
            Console.WriteLine("Результаты успешно очищены!");
        }
    }
}