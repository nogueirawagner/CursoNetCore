using EFCore.Models;
using EFCore.Models.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Data.Mappings
{
    public class BlogMap : EntityTypeConfiguration<Blog>
    {
        public override void Map(EntityTypeBuilder<Blog> builder)
        {
            builder
               .ToTable("Blog");

            builder
                .HasKey(s => s.BlogId);

            builder
                .Property(s => s.Url)
                .HasColumnName("Url")
                .HasColumnType("varchar(200)");

            builder
                .HasOne(b => b.Post)
                .WithOne(p => p.Blog)
                .HasForeignKey<Post>(b => b.BlogId);
        }
    }
}
