using ContactsAPI.Data;
using ContactsAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Linq.Expressions;

namespace ContactsAPI.Repository.RepositoryImpl
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;
        private readonly DbSet<TEntity> dbSet;
        public Repository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }


        public async Task CreateAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<TEntity> query = dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if(filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
            
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<TEntity> query = dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if(filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }
        public void Update(TEntity entity)
        {
            dbSet.Update(entity);

        }

        public async Task SaveAsync()
        {
           await context.SaveChangesAsync();
        }

    }
}
