using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsX.Repository.Interfaces
{
    // Interface para facilitação dos metodos base de um crud
    public interface IBaseRepository<TEntity, TEntityId>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TEntityId id);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity id);
        Task DeleteAsync(TEntityId id);
    }
}
