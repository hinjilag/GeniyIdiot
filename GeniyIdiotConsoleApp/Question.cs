namespace _12345
{
    public class Question
    {
        public string Text;
        public string Answer;

        // Статический метод для загрузки всех вопросов из файлов
        public static List<Question> GetAll(string textsPath, string answersPath)
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

        // Метод для сохранения всех вопросов в файлы
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

    }
}