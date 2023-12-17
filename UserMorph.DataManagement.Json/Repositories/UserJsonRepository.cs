using Newtonsoft.Json.Linq;
using UserMorph.Core.Interfaces.Persistence;

namespace UserMorph.DataManagement.Repositories
{
    public class UserJsonRepository: IUserJsonRepository
    {
        private readonly string filePath = "../UserMorph.DataManagement.Json/DataSource/Source.json";
        public string ReadUsersJson()
        {
            var json = File.ReadAllText(filePath);
            //var jObject = JObject.Parse(json);

            return json;
        }

        public string SaveUsersJson()
        {
            throw new NotImplementedException();
        }
    }
}
