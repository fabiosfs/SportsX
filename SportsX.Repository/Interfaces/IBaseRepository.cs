using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsX.Repository.Interfaces
{
    public interface IBaseRepository<TEntity, TEntityId>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TEntityId id);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity id);
        Task DeleteAsync(TEntityId id);
    }
}
