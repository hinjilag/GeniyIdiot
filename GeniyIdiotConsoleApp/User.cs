namespace _12345
{
    public class User
    {
        public string Name;
        public string Diagnoz;
        public int CorrectAnswersCount;

        public void SaveToFile(string path)
        {
            string record = $"{Name}#{Diagnoz}#{CorrectAnswersCount}";
            File.AppendAllText(path, record + Environment.NewLine);
        }

        public static List<User> LoadFromFile(string path)
        {
            List<User> users = new List<User>();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('#');
                    if (parts.Length == 3)
                    {
                        users.Add(new User
                        {
                            Name = parts[0],
                            Diagnoz = parts[1],
                            CorrectAnswersCount = int.Parse(parts[2])
                        });
                    }
                }
            }

            return users;
        }
    }
}