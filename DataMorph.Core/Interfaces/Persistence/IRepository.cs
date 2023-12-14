using System.Linq.Expressions;

namespace UserMorph.Core.Interfaces.Persistence
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(TKey key);

        //bool Any(Expression<Func<TEntity, bool>> expression);

        //void SaveChanges();
    }
}
