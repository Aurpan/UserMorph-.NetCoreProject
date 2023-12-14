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
    }
}