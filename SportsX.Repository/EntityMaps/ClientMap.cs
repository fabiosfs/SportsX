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

            builder.Property(x => x.CompanyName)
                .HasColumnName("CompanyName")
                .HasColumnType("varchar(100)");

            builder.Property(x => x.CpfCnpj)
                .HasColumnName("CpfCnpj")
                .HasColumnType("varchar(18)")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(x => x.Cep)
                .HasColumnName("Cep")
                .HasColumnType("varchar(10)");

            builder.Property(x => x.IdClassification)
                .HasColumnName("IdClassification")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.IdClientType)
                .HasColumnName("IdClientType")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(a => a.Classification)
                .WithMany(b => b.Clients)
                .HasForeignKey(b => b.IdClassification);

            builder.HasOne(a => a.ClientType)
                .WithMany(b => b.Clients)
                .HasForeignKey(b => b.IdClientType);

            builder.HasMany(x => x.Telephones)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.IdClient);
        }
    }
}
