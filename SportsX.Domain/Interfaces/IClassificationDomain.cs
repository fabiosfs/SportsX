using SportsX.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsX.Domain.Interfaces
{
    public interface IClassificationDomain
    {
        Task<IEnumerable<ClassificationDto>> GetAllAsync();

        Task<ClassificationDto> GetByIdAsync(int id);
    }
}
