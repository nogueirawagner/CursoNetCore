using EFCore.Models;
using EFCore.Models.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data.Mappings
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public override void Map(EntityTypeBuilder<Pessoa> builder)
        {
            builder
            .ToTable("Pessoa");

            builder.HasKey(s => s.Id);

            builder
            .Property(e => e.Nome)
            .HasColumnType("varchar(100)")
            .IsRequired();

            builder
            .Property(s => s.Sexo)
            .IsRequired();
        }
    }
}
