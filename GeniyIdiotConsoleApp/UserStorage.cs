using System.Collections.Generic;
using System.IO;

namespace _12345
{
    public class UserStorage
    {
        public void SaveToFile(User user1)
        {
            var results = FileStorage.ReadResults();
            results.Add(user1);
            FileStorage.WriteResults(results);
        }

        public List<User> GetAll()
        {
            return FileStorage.ReadResults();
        }
    }
}