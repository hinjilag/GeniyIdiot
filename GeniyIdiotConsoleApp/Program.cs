using System;
using System.Collections.Generic;
using System.IO;

namespace _12345
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игре гений-идиот! Как к вам обращаться ?");
            string userName = Console.ReadLine();
            while (true)
            {

                Console.WriteLine($"{userName}, выбери действие (введи номер)");
                Console.WriteLine();
                Console.WriteLine("""                   
                    1) играть    
                    2) смотреть результаты     
                    3) вход для админа                    
                    """);
                string messageMenu = Console.ReadLine();
                if (messageMenu == "5")
                {
                    return;
                }
                if (messageMenu == "2")
                {
                    Console.WriteLine("пользователь    К.В.О.   диагноз");
                    string[] fileData = File.ReadAllLines("..\\..\\..\\results.txt");

                    for (int i = 0; i < fileData.Length; i++)
                    {
                        string line = fileData[i];
                        string[] data = line.Split('#');
                        Console.WriteLine($"{data[0]} \t\t {data[1]} \t{data[2]}");
                    }
                }

                if (messageMenu == "3")
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
                            Console.WriteLine("1) добавить вопрос   2) удалить вопрос    3) отчистить результаты " +
                                "    4) выход из админки");
                            string actionAdm = Console.ReadLine();
                            if (actionAdm == "4")
                            {
                                break;
                            }
                            if (actionAdm == "3")
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
                    // АДМИН, ВВЕДИ КОЛИЧЕСТВО ВОПРОСОВ КОТОРЫЕ БУДУТ ЗАДАНЫ ПОЛЬЗОВАТЕЛЮ
                    double questionsCount = 5;

                    //начало игры

                    Console.WriteLine($"{userName}, отвечай на вопросы, и узнаешь свой диагноз");



                    bool isYes = YesOrNo("Готов ?");

                    Console.WriteLine();

                    if (isYes == false)
                    {
                        Console.WriteLine("До свидания");
                    }
                    else
                    {
                        while (true)
                        {
                            List<string> questions = new List<string>()
                    {
                        "четрые или пять?",
                        "сколько ног у осьминога",
                        "сколько пар завтра",
                        "сколько время",
                        "отчество Германа",
                        "конор или макгрегор",
                        "хабиб или нурмагомедов",
                        "питон или си шарп",
                    };
                            List<string> answers = new List<string>() { "5", "2", "4", "9:52",
                    "Вячеславоич", "конор", "хабиб", "си шарп" };

                            int сorrectAnswersCount = 0;

                            for (int i = 1; i <= questionsCount; i++) // сам тест 
                            {
                                int randomIndex = new Random().Next(0, answers.Count);
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

                            string diagnosis = DefinitDiagnosis(сorrectAnswersCount, questionsCount);
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


    }

}
