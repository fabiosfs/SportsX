using SportsX.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsX.Domain.Interfaces
{
    public interface ITelephoneDomain
    {
        Task<IEnumerable<TelephoneDto>> UpdateAsync(IEnumerable<TelephoneDto> telephones, int idClient);
    }
}
