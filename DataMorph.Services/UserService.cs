using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using UserMorph.Core.DTOs.DomainModels;
using UserMorph.Core.Interfaces.Domain;
using UserMorph.DataManagement.Repositories;

namespace UserMorph.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public IEnumerable<User> GetUsers()
        {
            var users = _userRepository.GetUsers()
                .Select(u => new User
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Company = u.Company,
                    IsActive = u.IsActive,
                    Sex = u.Sex.ToString()
                });

            return users;
        }

        public User GetUserDetailsByID(int id)
        {
            var userPersistence = _userRepository.GetUserDetailsByID(id);

            return MapPersistenceUserToDomainUser(userPersistence);
        }


        private User MapPersistenceUserToDomainUser(Core.DTOs.PersistenceModels.User source)
        {
            if (source != null)
            {
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
                    })
                };
            }

            return null;
        }
    }
}