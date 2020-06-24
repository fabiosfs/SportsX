using SportsX.Repository.Entities;
using SportsX.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SportsX.Repository.Services
{
    public class ClientRepository : BaseRepository<Client, int>, IClientRepository
    {
        public ClientRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}

