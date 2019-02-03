using EFCore.Models;
using EFCore.Models.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data.Mappings
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public override void Map(EntityTypeBuilder<Endereco> builder)
        {
            builder
                .ToTable("Endereco");

            builder
                .HasKey(s => s.Id);

            builder
                .Property(e => e.Logradouro)
                       .IsRequired()
                       .HasColumnType("varchar(150)");

            builder
                .Property(e => e.Numero)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder
                .Property(e => e.Bairro)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder
                .Property(e => e.CEP)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder
                .Property(e => e.Complemento)
                .HasColumnType("varchar(100)");

            builder
                .Property(e => e.Cidade)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .Property(e => e.Estado)
                .IsRequired()
                .HasColumnType("varchar(100)");
        }
    }
}
