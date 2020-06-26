using SportsX.Repository.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsX.Repository.Interfaces
{
    public interface ITelephoneRepository : IBaseRepository<Telephone, int>
    {
        Task<IEnumerable<Telephone>> UpdateAsync(IEnumerable<Telephone> telephones, int idClient);
    }
}
