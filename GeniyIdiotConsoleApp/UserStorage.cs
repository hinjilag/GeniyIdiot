using System.Xml.Linq;

namespace _12345
{
    public class UserStorage
    {
        public string path = "..//..//..//results.txt";
        
        public void SaveToFile(User user1)
        {
            string record = $"{user1.Name}#{user1.Diagnoz}#{user1.CorrectAnswersCount}";
            File.AppendAllText(path, record + Environment.NewLine);
        }

        public List<User> GetAll(string path)
        {
            List<User> users = new List<User>();

            if (File.Exists(path)) // есть ли файл проверяет, тру фолс 
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('#');
                    if (parts.Length == 3)
                    {
                        User user = new User();
                        user.Name = parts[0];
                        user.Diagnoz = parts[1];
                        user.CorrectAnswersCount = int.Parse(parts[2]);
                        users.Add(user);
                    }
                }
            }

            return users;
        }
        
    }
}