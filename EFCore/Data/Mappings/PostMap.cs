using EFCore.Models;
using EFCore.Models.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data.Mappings
{
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public override void Map(EntityTypeBuilder<Post> builder)
        {
            builder
               .ToTable("Post");

            builder
                .Property(p => p.Titulo)
                .HasColumnType("varchar(150)");

            builder
               .Property(p => p.Conteudo)
               .HasColumnType("varchar(500)");
        }
    }
}
