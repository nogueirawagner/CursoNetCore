using EFCore.Models;
using EFCore.Models.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data.Mappings
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public override void Map(EntityTypeBuilder<Categoria> builder)
        {
            builder
               .HasKey(s => s.Id);

            builder
                .Property(s => s.Nome)
                .HasColumnType("varchar(150");
        }
    }
}
