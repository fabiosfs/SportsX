using SportsX.Repository.Entities;
using SportsX.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SportsX.Repository.Services
{
    public class ClientTypeRepository : BaseRepository<ClientType, int>, IClientTypeRepository
    {
        public ClientTypeRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}

