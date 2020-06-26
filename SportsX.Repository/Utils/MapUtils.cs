using SportsX.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace SportsX.Repository.Utils
{
    // Classe para facilitar o mapeamento das colunas padrão
    static class MapUtils<TEntity, TEntityId>
        where TEntity : BaseEntity<TEntityId>
        where TEntityId : struct
    {
        public static EntityTypeBuilder<TEntity> builderDefaultColumns(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int");

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.DtCriation)
                .HasColumnName("DtCriation")
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.DtUpdated)
                .HasColumnName("DtUpdated")
                .HasColumnType("datetime");
            
            return builder;
        }
    }
}
