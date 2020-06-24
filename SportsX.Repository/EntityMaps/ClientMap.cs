using SportsX.Repository.Entities;
using SportsX.Repository.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportsX.Repository.EntityMaps
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder = MapUtils<Client, int>.builderDefaultColumns(builder);

            builder.ToTable("Client");

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}
