using UserMorph.Core.DTOs.PersistenceModels;
using Microsoft.EntityFrameworkCore;
using UserMorph.Core.Interfaces.Persistence;

namespace UserMorph.DataManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;
        public UserRepository(DbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Set<User>();
        }

        public User GetUserDetailsByID(int id)
        {
            var userDetails = _context.Set<User>()
                .Where(u => u.Id == id)
                .Include(u => u.Contacts)
                .Include(u => u.Roles).FirstOrDefault();

            return userDetails;
                
        }
    }
}
