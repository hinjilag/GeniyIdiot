namespace _12345
{
    public class QuestionsStorage
    {
        private string textsPath = "..//..//..//questions.txt";
        private string answersPath = "..//..//..//answers.txt";

        public List<Question> GetAll()
        {
            return Question.GetAll(textsPath, answersPath);
        }

        public int AskQuestions(List<Question> questionsForTest, List<string> userAnswers)
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

        public List<Question> GetRandomQuestions(int count)
        {
            List<Question> allQuestions = GetAll();
            List<Question> randomQuestions = new List<Question>();
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
            List<Question> questions = Question.GetAll(textsPath, answersPath);

            if (questionNumber >= 0 && questionNumber < questions.Count)
            {
                questions.RemoveAt(questionNumber);
                Question.SaveToFiles(questions, textsPath, answersPath);
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