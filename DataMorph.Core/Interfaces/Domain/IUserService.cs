using UserMorph.Core.DTOs.DomainModels;
using UserMorph.Core.Enums;

namespace UserMorph.Core.Interfaces.Domain
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers(DataSourceType sourceType);
        User GetUserDetailsById(int id, DataSourceType sourceType);
        
    }
}