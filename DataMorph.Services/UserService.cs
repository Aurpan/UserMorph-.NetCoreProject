using Newtonsoft.Json;
using UserMorph.Core.DTOs.DomainModels;
using UserMorph.Core.Enums;
using UserMorph.Core.Interfaces.Domain;
using UserMorph.Core.Interfaces.Persistence;

namespace UserMorph.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepositoryFactory _repositoryFactory;

        public UserService(UserRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public IEnumerable<User> GetUsers(DataSourceType sourceType)
        {    
            return ReadAllJsonData();
        } 


        public User GetUserDetailsById(int id, DataSourceType sourceType)
        {
            var userPersistence = _repositoryFactory.GetUserRepository(sourceType).GetUserDetailsByID(id);

            return MapPersistenceUserToDomainUserWithDetails(userPersistence);
        }


        public void CreateUser(User user) 
        {
            var users = ReadAllJsonData();

            users.Add(user);
        }


        private User MapPersistenceUserToDomainUserWithDetails(Core.DTOs.PersistenceModels.User source)
        {
            if (source == null) { return null; }

            return new User
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Company = source.Company,
                IsActive = source.IsActive,
                Sex = source.Sex.ToString(),
                Contacts = source.Contacts.Select(uc => new UserContact
                {
                    Id = uc.Id,
                    Address = uc.Address,
                    City = uc.City,
                    Country = uc.Country,
                    Phone = uc.Phone,
                    UserId = uc.UserId,
                }),
                Roles = source.Roles.Select(r => new Role
                {
                    UserId = r.UserId,
                    RoleId = r.RoleId,
                    Name = r.RoleId.ToString()
                })
            };
            
        }

        private List<User> ReadAllJsonData()
        {
            var users = _repositoryFactory.GetUserRepository(DataSourceType.Json).GetUsers();

            return users.Select(MapPersistenceUserToDomainUserWithDetails).ToList();
        }
    }
}
