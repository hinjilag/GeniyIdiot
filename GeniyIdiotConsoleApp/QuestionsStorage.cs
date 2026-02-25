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

        // Новый метод для проведения тестирования
        public int AskQuestions(User user, int questionsCount)
        {
            List<Question> allQuestions = GetAll();
            List<Question> questionsForTest = new List<Question>(allQuestions);

            int correctAnswers = 0;

            for (int i = 1; i <= questionsCount; i++)
            {
                // Выбираем случайный вопрос
                int randomIndex = new Random().Next(0, questionsForTest.Count);
                Question currentQuestion = questionsForTest[randomIndex];

                // Задаем вопрос пользователю
                Console.Write($"{i}) ");
                Console.WriteLine(currentQuestion.Text);

                // Получаем ответ
                string userAnswer = Console.ReadLine();

                // Проверяем правильность
                if (currentQuestion.Answer == userAnswer)
                {
                    correctAnswers++;
                }

                // Удаляем использованный вопрос
                questionsForTest.RemoveAt(randomIndex);
            }

            return correctAnswers;
        }
    }
}