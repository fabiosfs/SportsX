using Microsoft.EntityFrameworkCore;
using SportsX.Repository.Entities;
using SportsX.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsX.Repository.Services
{
    // Classe para facilitação de implementação dos metodos base de um crud
    public class BaseRepository<TEntity, TEntityId> : IBaseRepository<TEntity, TEntityId>
        where TEntity : BaseEntity<TEntityId>
        where TEntityId : struct
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var response = await _dbSet.Where(x => !x.Excluded).ToListAsync();
            return response;
        }

        public virtual async Task<TEntity> GetByIdAsync(TEntityId id)
        {
            var response = await _dbSet.FindAsync(id);
            
            if (!response.Excluded)
                return null;

            return response;
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entityDb = await GetByIdAsync(entity.Id);
            entity.DtCriation = entityDb.DtCriation;
            _dbContext.Entry(entityDb).Property(x => x.Id).IsModified = false;
            _dbContext.Entry(entityDb).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return entityDb;
        }

        public virtual async Task DeleteAsync(TEntityId id)
        {
            var entityDb = await GetByIdAsync(id);
            entityDb.Excluded = true;
            _dbContext.Entry(entityDb).CurrentValues.SetValues(entityDb);
            await _dbContext.SaveChangesAsync();
        }
    }
}
