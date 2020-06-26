using SportsX.Repository.Entities;
using SportsX.Repository.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportsX.Repository.EntityMaps
{
    public class TelephoneMap : IEntityTypeConfiguration<Telephone>
    {
        public void Configure(EntityTypeBuilder<Telephone> builder)
        {
            builder = MapUtils<Telephone, int>.builderDefaultColumns(builder);

            builder.ToTable("Telephone");

            builder.Property(x => x.IdClient)
                .HasColumnName("IdClient")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Number)
                .HasColumnName("Number")
                .HasColumnType("varchar(15)");

            builder.HasOne(a => a.Client)
                .WithMany(b => b.Telephones)
                .HasForeignKey(b => b.IdClient);
        }
    }
}
