using UserMorph.Core.DTOs.DomainModels;

namespace UserMorph.Core.Interfaces.Domain
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
    }
}