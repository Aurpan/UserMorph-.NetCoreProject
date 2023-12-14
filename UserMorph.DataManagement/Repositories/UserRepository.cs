using UserMorph.Core.DTOs.PersistenceModels;
using Microsoft.EntityFrameworkCore;

namespace UserMorph.DataManagement.Repositories
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        private readonly DbContext _context;
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Set<User>();
        }
    }
}
