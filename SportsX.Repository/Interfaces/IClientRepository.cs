using SportsX.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsX.Repository.Interfaces
{
    public interface IClientRepository : IBaseRepository<Client, int>
    {
        Task<IEnumerable<Client>> GetAllAsync(int? idClientType);
    }
}
