using Curso.Domain.Models;
using Curso.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curso.Infra.Data.Mappings
{
    public class EventoMap : EntityTypeConfiguration<Evento>
    {
        public override void Map(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("Evento");

            builder.Property(e => e.Nome)
           .HasColumnType("varchar(150)")
           .IsRequired();

            builder.Property(e => e.Descricao)
            .HasColumnType("varchar(150)");

            builder.Property(e => e.Gratuito)
            .IsRequired();

            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);
        }
    }
}
