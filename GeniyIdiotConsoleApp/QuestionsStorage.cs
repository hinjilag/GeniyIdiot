namespace _12345
{
    public class QuestionsStorage
    {
        public static string textsPath = "..//..//..//questions.txt";
        public static string answersPath = "..//..//..//answers.txt";
        public static string resultsPath = "..//..//..//results.txt";


        public static List<Question> GetAll()
        {

            string[] questionsTexts = File.ReadAllLines(textsPath);
            string[] questionsAnswers = File.ReadAllLines(answersPath);

            List<Question> questions = new List<Question>();
            for (int i = 0; i < questionsTexts.Length; i++)
            {
                Question question = new Question();
                question.Text = questionsTexts[i];
                question.Answer = questionsAnswers[i];
                questions.Add(question);
            }
            return questions;
        }
        public static void SaveToFiles(List<Question> questions, string textsPath, string answersPath)
        {
            List<string> texts = new List<string>();
            List<string> answers = new List<string>();

            foreach (Question question in questions)
            {
                texts.Add(question.Text);
                answers.Add(question.Answer);
            }

            File.WriteAllLines(textsPath, texts);
            File.WriteAllLines(answersPath, answers);
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
                QuestionsStorage.SaveToFiles(questions, textsPath, answersPath);
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