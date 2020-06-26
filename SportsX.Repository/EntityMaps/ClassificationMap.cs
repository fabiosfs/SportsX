using SportsX.Repository.Entities;
using SportsX.Repository.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportsX.Repository.EntityMaps
{
    public class ClassificationMap : IEntityTypeConfiguration<Classification>
    {
        public void Configure(EntityTypeBuilder<Classification> builder)
        {
            builder = MapUtils<Classification, int>.builderDefaultColumns(builder);

            builder.ToTable("Classification");

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasMany(x => x.Clients)
                .WithOne(x => x.Classification)
                .HasForeignKey(x => x.IdClassification);
        }
    }
}
