using SportsX.Repository.Entities;
using SportsX.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SportsX.Repository.Services
{
    public class ClassificationRepository : BaseRepository<Classification, int>, IClassificationRepository
    {
        public ClassificationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}

