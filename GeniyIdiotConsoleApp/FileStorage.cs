using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace _12345
{
    public class FileStorage
    {
        public static string textsPath = "..//..//..//questions.json";        
        public static string resultsPath = "..//..//..//results.json";

        public static List<Question> ReadQuestions()
        {
            if (!File.Exists(textsPath))
            {
                return new List<Question>();
            }

            string json = File.ReadAllText(textsPath);
            return JsonSerializer.Deserialize<List<Question>>(json);
        }

        public static void WriteQuestions(List<Question> questions)
        {
            string json = JsonSerializer.Serialize(questions);
            File.WriteAllText(textsPath, json);
        }

        public static List<UserMy> ReadResults()
        {
            if (!File.Exists(resultsPath))
            {
                return new List<UserMy>();
            }               
            string json = File.ReadAllText(resultsPath);
            return JsonSerializer.Deserialize<List<UserMy>>(json);
        }

        public static void WriteResults(List<UserMy> results)
        {
            string json = JsonSerializer.Serialize(results);
            File.WriteAllText(resultsPath, json);
        }

        public static string[] ReadAllLines(string type)
        {
            if (type == "results")
            {
                var results = ReadResults();
                string[] lines = new string[results.Count];
                for (int i = 0; i < results.Count; i++)
                {
                    lines[i] = $"{results[i].Name}#{results[i].CorrectAnswersCount}#{results[i].Diagnoz}";
                }
                return lines;
            }
            else if (type == "questions")
            {
                var questions = ReadQuestions();
                string[] lines = new string[questions.Count];
                for (int i = 0; i < questions.Count; i++)
                {
                    lines[i] = questions[i].Text;
                }
                return lines;
            }
            else if (type == "answers")
            {
                var questions = ReadQuestions();
                string[] lines = new string[questions.Count];
                for (int i = 0; i < questions.Count; i++)
                {
                    lines[i] = questions[i].Answer;
                }
                return lines;
            }
            return new string[0];
        }

        public static void AppendAllText(string addQuestion, string addAnswer)
        {
            var questions = ReadQuestions();
            questions.Add(new Question { Text = addQuestion, Answer = addAnswer });
            WriteQuestions(questions);
        }

        public static void WriteAllLines(List<string> questions, List<string> answers)
        {
            var questionList = new List<Question>();
            for (int i = 0; i < questions.Count; i++)
            {
                questionList.Add(new Question { Text = questions[i], Answer = answers[i] });
            }
            WriteQuestions(questionList);
        }

        public static void ClearResults()
        {
            WriteResults(new List<UserMy>());
        }
    }
}