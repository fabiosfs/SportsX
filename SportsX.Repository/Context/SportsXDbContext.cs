
using Microsoft.EntityFrameworkCore;
using SportsX.Repository.EntityMaps;

namespace SportsX.Repository.Context
{
    public class SportsXDbContext : DbContext
    {
        public SportsXDbContext(DbContextOptions<SportsXDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfiguration(new ClientTypeMap());
            modelBuilder.ApplyConfiguration(new ClassificationMap());
        }
    }
}
