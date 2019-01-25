using EFCore.Models;
using EFCore.Models.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Data.Mappings
{
    public class EventoMap : EntityTypeConfiguration<Evento>
    {
        public override void Map(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("Evento");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
             .HasColumnType("varchar(150)")
             .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Valor)
                 .HasColumnType("decimal");
        }
    }
}
