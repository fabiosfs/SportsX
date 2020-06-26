using Microsoft.EntityFrameworkCore;
using SportsX.Repository.Entities;
using SportsX.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsX.Repository.Services
{
    public class ClientRepository : BaseRepository<Client, int>, IClientRepository
    {
        public ClientRepository(DbContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<Client>> GetAllAsync(int? idClientType)
        {
            var response = await _dbSet
                .Include(x => x.ClientType)
                .Include(x => x.Classification)
                .Include(x => x.Telephones)
                .Where(x => idClientType == null || x.IdClientType == idClientType)
                .ToListAsync();

            return response;
        }

        public override async Task<Client> GetByIdAsync(int id)
        {
            var response = await _dbSet
                .Include(x => x.ClientType)
                .Include(x => x.Classification)
                .Include(x => x.Telephones)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return response;
        }
    }
}

