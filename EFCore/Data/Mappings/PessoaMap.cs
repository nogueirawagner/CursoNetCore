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
                .Property(s => s.Id);

            builder
                .ToTable("Pessoa");

            builder
                .Property(s => s.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
                .Property(s => s.CPF)
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder
                .Property(s => s.Idade)
                .IsRequired();

            builder
                .Property(s => s.Sexo)
                .IsRequired();
        }
    }
}
