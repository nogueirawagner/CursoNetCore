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

            builder.HasKey(s => s.Id);

            builder
                .Property(s => s.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
              .Property(s => s.Descricao)
              .HasColumnType("varchar(150)")
              .IsRequired();

            builder
                .Property(s => s.Valor)
                .HasColumnType("decimal(15,2)")
                .IsRequired();

            builder
                .HasOne(e => e.Categoria)
                .WithMany(c => c.Eventos);
        }
    }
}
