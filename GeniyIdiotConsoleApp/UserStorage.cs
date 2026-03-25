using System.Collections.Generic;
using System.IO;

namespace _12345
{
    public class UserStorage
    {
        public void SaveToFile(UserMy user1)
        {
            List<UserMy> results = FileStorage.ReadResults();
            results.Add(user1);
            FileStorage.WriteResults(results);
        }

        public List<UserMy> GetAll()
        {
            return FileStorage.ReadResults();
        }
    }
}