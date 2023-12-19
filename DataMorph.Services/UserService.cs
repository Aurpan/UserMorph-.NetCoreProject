using UserMorph.Core.ApplicationExceptions;
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

        public IEnumerable<User> GetUsers(DataSourceType sourceType, string searchText)
        {
            var userQuery = _repositoryFactory.GetUserRepository(sourceType)
                .GetUsers();

            if (userQuery == null)
            {
                return Enumerable.Empty<User>();
            }

            if (!string.IsNullOrEmpty(searchText) && searchText != "~")
            {
                userQuery = userQuery
                    .Where(u => 
                        u.FirstName.Contains(searchText, StringComparison.OrdinalIgnoreCase) 
                        || u.LastName.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                    );
            }

            var filteredResult = userQuery.Select(MapToUserDomainModel)
                .ToList();

            return filteredResult;
        } 

        public User GetUserDetailsById(int id, DataSourceType sourceType)
        {
            var userPersistence = _repositoryFactory.GetUserRepository(sourceType)
                .GetUserDetailsByID(id);

            if (userPersistence is null)
            {
                throw new NotFoundException($"User with id = {id} not found!");
            }

            return MapToUserDetailDomainModel(userPersistence);
        }


        public void UpdateUser(User user) 
        {
            var users = _repositoryFactory.GetUserRepository(DataSourceType.Json)
                .GetUsers();

            if (users is null)
            {
                throw new NotFoundException($"No user found!");
            }

            var userList = users.ToList();

            int index = userList.FindIndex(u => u.Id == user.Id);

            if (index == -1)
            {
                throw new NotFoundException($"User with id = {user.Id} not found!");
            }

            userList[index] = MapToUserDetailPersistenceModel(user);

            var jsonRepository = ((Core.Interfaces.Persistence.IUserJsonRepository)_repositoryFactory
                .GetUserRepository(DataSourceType.Json));
            
            jsonRepository.UpdateJsonDb(userList);

        }


        public void DeleteUser(int userId) 
        {
            var allUsers = _repositoryFactory.GetUserRepository(DataSourceType.Json)
                .GetUsers();

            if (allUsers is null)
            {
                throw new NotFoundException($"No user found!");
            }

            var userList = allUsers.ToList();
            int index = userList.FindIndex(u => u.Id == userId);

            if (index == -1)
            {
                throw new NotFoundException($"User with id = {userId} not found!");
            }

            userList.RemoveAt(index);

            var jsonRepository = ((Core.Interfaces.Persistence.IUserJsonRepository)_repositoryFactory
                .GetUserRepository(DataSourceType.Json));

            jsonRepository.UpdateJsonDb(userList);
        }

        public void CreateUser(User user)
        {
            var users = _repositoryFactory.GetUserRepository(DataSourceType.Json)
                .GetUsers();

            if (users is null)
            {
                throw new NotFoundException($"No user found!");
            }

            users.ToList().Add(MapToUserDetailPersistenceModel(user));

            var jsonRepository = ((Core.Interfaces.Persistence.IUserJsonRepository)_repositoryFactory
                .GetUserRepository(DataSourceType.Json));

            jsonRepository.UpdateJsonDb(users.ToList());
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
