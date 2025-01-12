
using ContactManagerApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactManagerApplication.Repository
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
    where TEntity : class
    where TKey : IEquatable<TKey>
    {
        private readonly ContactDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public BaseRepository(ContactDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.ToListAsync();
        }
        public virtual async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(id);
        }
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _dbSet.Add(entity);
            }
        }
        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
