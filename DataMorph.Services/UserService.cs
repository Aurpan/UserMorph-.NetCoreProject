using UserMorph.Core.DTOs.DomainModels;
using UserMorph.Core.Enums;
using UserMorph.Core.Interfaces.Domain;

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
            return _repositoryFactory.GetUserRepository(sourceType)
                .GetUsers()
                .Select(MapToUserDomainModel)
                .ToList();
        } 


        public User GetUserDetailsById(int id, DataSourceType sourceType)
        {
            var userPersistence = _repositoryFactory.GetUserRepository(sourceType).GetUserDetailsByID(id);

            return MapToUserDetailDomainModel(userPersistence);
        }


        public void UpdateUser(User user) 
        {
            var users = _repositoryFactory.GetUserRepository(DataSourceType.Json)
                .GetUsers()
                .ToList();

            
            int index = users.FindIndex(u => u.Id == user.Id);
            users[index] = MapToUserDetailPersistenceModel(user);

            var jsonRepository = ((Core.Interfaces.Persistence.IUserJsonRepository)_repositoryFactory
                .GetUserRepository(DataSourceType.Json));
            
            jsonRepository.UpdateUser(users);

        }


        public void DeleteUser(int userId) 
        {
            var users = _repositoryFactory.GetUserRepository(DataSourceType.Json)
                .GetUsers()
                .ToList();

            int index = users.FindIndex(u => u.Id == userId);
            users.RemoveAt(index);

            var jsonRepository = ((Core.Interfaces.Persistence.IUserJsonRepository)_repositoryFactory
                .GetUserRepository(DataSourceType.Json));

            jsonRepository.DeleteUser(users);
        }

        public void CreateUser(User user)
        {
            var users = _repositoryFactory.GetUserRepository(DataSourceType.Json)
            .GetUsers()
                .ToList();

            users.Add(MapToUserDetailPersistenceModel(user));

            var jsonRepository = ((Core.Interfaces.Persistence.IUserJsonRepository)_repositoryFactory
                .GetUserRepository(DataSourceType.Json));

            jsonRepository.UpdateUser(users);
        }


        private User MapToUserDomainModel(Core.DTOs.PersistenceModels.User user) 
        {
            if (user == null) return null;
            return new User
            {
                Id = user.Id,
                Company = user.Company,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Sex = user.Sex,
                IsActive = user.IsActive,
            };
        }

        private User MapToUserDetailDomainModel(Core.DTOs.PersistenceModels.User source)
        {
            if (source == null) { return null; }

            return new User
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Company = source.Company,
                IsActive = source.IsActive,
                Sex = source.Sex,
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
                    RoleId = r.RoleId
                })
            };
            
        }


        private Core.DTOs.PersistenceModels.User MapToUserDetailPersistenceModel(User source)
        {
            if (source == null) { return null; }

            return new Core.DTOs.PersistenceModels.User
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Company = source.Company,
                IsActive = source.IsActive,
                Sex = source.Sex,
                Contacts = source.Contacts.Select(uc => new Core.DTOs.PersistenceModels.UserContact
                {
                    Id = uc.Id,
                    Address = uc.Address,
                    City = uc.City,
                    Country = uc.Country,
                    Phone = uc.Phone,
                    UserId = uc.UserId,
                }).ToList(),
                Roles = source.Roles.Select(r => new Core.DTOs.PersistenceModels.UsersRole
                {
                    UserId = r.UserId,
                    RoleId = r.RoleId
                }).ToList()
            };

        }
    }
}
