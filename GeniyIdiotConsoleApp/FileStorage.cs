namespace _12345
{
    public class FileStorage
    {
        public static string textsPath = "..//..//..//questions.txt";
        public static string answersPath = "..//..//..//answers.txt";
        public static string resultsPath = "..//..//..//results.txt";

        public static string[] ReadAllLines(string type)
        {
            if (type == "results")
            {
                string[] read = File.ReadAllLines(resultsPath);
                return read;
            }
            else if (type == "questions")
            {
                string[] read = File.ReadAllLines(textsPath);
                return read;
            }
            else if (type == "answers")
            {
                string[] read = File.ReadAllLines(answersPath);
                return read;
            }
            return new string[0];
        }

        public static void AppendAllText(string addQuestion, string addAnswer)
        {
            File.AppendAllText(textsPath, addQuestion + Environment.NewLine);
            File.AppendAllText(answersPath, addAnswer + Environment.NewLine);
        }

        public static void WriteAllLines(List<string> questions, List<string> answers)
        {
            File.WriteAllLines(textsPath, questions);
            File.WriteAllLines(answersPath, answers);
        }

        public static void ClearResults()
        {
            File.WriteAllText(resultsPath, string.Empty);
        }
    }
}