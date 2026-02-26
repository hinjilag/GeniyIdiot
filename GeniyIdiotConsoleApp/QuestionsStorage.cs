namespace _12345
{
    public class QuestionsStorage
    {
        string textsPath = "..//..//..//questions.txt";
        string answersPath = "..//..//..//answers.txt";

        public List<Question> GetAll()
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

        // спрашивай!!!
        public int AskQuestions(User user, int questionsCount)
        {
            List<Question> allQuestions = GetAll();
            List<Question> questionsForTest = new List<Question>(allQuestions);

            int correctAnswers = 0;

            for (int i = 1; i <= questionsCount; i++)
            {
                // выбираем случайный вопрос
                int randomIndex = new Random().Next(0, questionsForTest.Count);
                Question currentQuestion = questionsForTest[randomIndex];

                // задаем вопрос пользователю
                Console.Write($"{i}) ");
                Console.WriteLine(currentQuestion.Text);

                // получаем ответ
                string userAnswer = Console.ReadLine();

                // проверяем правильность
                if (currentQuestion.Answer == userAnswer)
                {
                    correctAnswers++;
                }

                // удаляем заданный вопрос
                questionsForTest.RemoveAt(randomIndex);
            }

            return correctAnswers;
        }

        public void DeleteQuestion()
        {
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
        }
    }
}