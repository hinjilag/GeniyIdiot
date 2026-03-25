using System.Text.Json;

namespace _12345
{
    public class QuestionsStorage
    {
        public static string questionPath = "..//..//..//questions.json";
        
        public static string resultsPath = "..//..//..//results.json";


        public static List<Question> GetAll()
        {

            List<Question> questions = FileStorage.ReadQuestions();
            return questions;
        }
        public static void SaveToFiles(List<Question> questions, string questionPath)
        {
            string jsonString = JsonSerializer.Serialize(questions);
            File.WriteAllText(questionPath, jsonString);
        }

        public static int AskQuestions(List<Question> questionsForTest, List<string> userAnswers)
        {
            int correctAnswers = 0;

            for (int i = 0; i < questionsForTest.Count; i++)
            {
                if (questionsForTest[i].Answer == userAnswers[i])
                {
                    correctAnswers++;
                }
            }

            return correctAnswers;
        }

        public static List<Question> GetRandomQuestions(int count)
        {
            List<Question> allQuestions = GetAll(); // все вопросы 
            List<Question> randomQuestions = new List<Question>(); // пустой лист с потенциально заданными вопросами 
            Random random = new Random();

            List<Question> tempList = new List<Question>(allQuestions); 

            for (int i = 0; i < count && tempList.Count > 0; i++)
            {
                int randomIndex = random.Next(0, tempList.Count);
                randomQuestions.Add(tempList[randomIndex]);
                tempList.RemoveAt(randomIndex);
            }

            return randomQuestions;
        }

        public bool DeleteQuestion(int questionNumber)
        {
            List<Question> questions = GetAll();
            
            if (questionNumber >= 0 && questionNumber < questions.Count)
            {
                questions.RemoveAt(questionNumber);
                QuestionsStorage.SaveToFiles(questions, questionPath);
                return true;
            }

            return false;
        }

        public int GetQuestionsCount()
        {
            return GetAll().Count;
        }        
    }
}