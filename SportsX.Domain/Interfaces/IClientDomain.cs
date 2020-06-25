using SportsX.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsX.Domain.Interfaces
{
    public interface IClientDomain
    {
        Task<IEnumerable<ClientDto>> GetAllAsync();
        Task<ClientDto> GetByIdAsync(int id);
        Task<ClientDto> InsertAsync(ClientDto client);
        Task<ClientDto> UpdateAsync(ClientDto client);
        Task DeleteAsync(int id);
    }
}
