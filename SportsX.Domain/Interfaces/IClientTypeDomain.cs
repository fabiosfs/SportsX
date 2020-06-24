using SportsX.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsX.Domain.Interfaces
{
    public interface IClientTypeDomain
    {
        Task<IEnumerable<ClientTypeDto>> GetAllAsync();

        Task<ClientTypeDto> GetByIdAsync(int id);
    }
}
