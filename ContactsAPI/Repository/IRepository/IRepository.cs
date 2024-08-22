using System.Linq.Expressions;

namespace ContactsAPI.Repository.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true);
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task SaveAsync();
    }
}
