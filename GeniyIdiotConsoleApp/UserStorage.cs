namespace _12345
{
    public class UserStorage
    {
        private string path = "..//..//..//results.txt";

        public void SaveRecord(User user)
        {
            user.SaveToFile(path);
        }

        public List<User> GetAllUsers()
        {
            return User.LoadFromFile(path);
        }
    }
}