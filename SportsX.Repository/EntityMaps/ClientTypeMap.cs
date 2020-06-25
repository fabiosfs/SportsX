using SportsX.Repository.Entities;
using SportsX.Repository.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportsX.Repository.EntityMaps
{
    public class ClientTypeMap : IEntityTypeConfiguration<ClientType>
    {
        public void Configure(EntityTypeBuilder<ClientType> builder)
        {
            builder = MapUtils<ClientType, int>.builderDefaultColumns(builder);

            builder.ToTable("ClientType");

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasMany(x => x.Clients)
                .WithOne(x => x.ClientType)
                .HasForeignKey(x => x.IdClientType);
        }
    }
}
