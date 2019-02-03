using EFCore.Data.Mappings;
using EFCore.Models;
using EFCore.Models.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Data.Context
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {
        }

        public DbSet<Evento> Evento { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new PessoaMap());
            modelBuilder.AddConfiguration(new BlogMap());
            modelBuilder.AddConfiguration(new CategoriaMap());
            modelBuilder.AddConfiguration(new EnderecoMap());
            modelBuilder.AddConfiguration(new EventoMap());
            modelBuilder.AddConfiguration(new PostMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<EFCore.Models.Blog> Blog { get; set; }

        public DbSet<EFCore.Models.Post> Post { get; set; }
    }
}
