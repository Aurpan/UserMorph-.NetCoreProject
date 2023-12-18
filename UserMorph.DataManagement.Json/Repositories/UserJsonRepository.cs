using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UserMorph.Core.DTOs.PersistenceModels;
using UserMorph.Core.Interfaces.Persistence;

namespace UserMorph.DataManagement.Repositories
{
    public class UserJsonRepository: IUserJsonRepository, IRepository
    {
        private readonly string filePath = "../UserMorph.DataManagement.Json/DataSource/Source.json";


        public IEnumerable<User> GetUsers()
        {
            return GetUsersFromJson();
        }

        public User GetUserDetailsByID(int id)
        {
            return GetUsersFromJson().FirstOrDefault(u => u.Id == id);
        }



        #region Private Methods

        private IEnumerable<User> GetUsersFromJson()
        {
            string usersJson = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<IEnumerable<User>>(usersJson);
        }

        private void WriteToJsonDataSource(string userJson)
        {
            File.WriteAllText(filePath, userJson);
        }

        #endregion
    
    }
}
