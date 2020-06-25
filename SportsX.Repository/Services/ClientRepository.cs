using SportsX.Repository.Entities;
using SportsX.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SportsX.Repository.Services
{
    public class ClientRepository : BaseRepository<Client, int>, IClientRepository
    {
        public ClientRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Client>> GetAllAsync()
        {
            var retorno = await _dbSet
                .Include(x => x.ClientType)
                .Include(x => x.Classification)
                .Where(x => !x.Excluded)
                .ToListAsync();
            return retorno;
        }

        public virtual async Task<Client> GetByIdAsync(int id)
        {
            var retorno = await _dbSet
                .Include(x => x.ClientType)
                .Include(x => x.Classification)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (retorno == null || retorno.Excluded)
                retorno = null;

            return retorno;
        }
    }
}

