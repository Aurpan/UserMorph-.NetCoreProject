using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UserMorph.Core.Interfaces.Persistence;

namespace UserMorph.DataManagement.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _table;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<TEntity>();
        }

        public TEntity Get(TKey key) => _table.Find(key)!;

        public IEnumerable<TEntity> GetAll() => _table;


        //public bool Any(Expression<Func<TEntity, bool>> expression) => _table.Any(expression);

        //public void SaveChanges()
        //{
        //    _dbContext.SaveChanges();
        //}
    }
}
