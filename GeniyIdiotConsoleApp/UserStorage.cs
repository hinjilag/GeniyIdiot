namespace _12345
{
    public class UserStorage
    {
        private string path = "..//..//..//results.txt";
        public void SaveRecord(User user)
        {
            string formatRecord = $"{user.Name}#{user.Diagnoz}#{user.CorrectAnswersCount}";
            File.AppendAllText(path, formatRecord + Environment.NewLine);
        }
    }
}