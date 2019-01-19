using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Data
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options)
            :base(options)
        {

        }

        public DbSet<Evento> Evento { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>()
                .Property(c => c.Id)
                .HasColumnName("EventoId");

            modelBuilder.Entity<Evento>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Evento>()
                .Property(c => c.Descricao)
                 .HasColumnType("varchar")
                .HasMaxLength(500);

            modelBuilder.Entity<Pessoa>()
                .Property(c => c.Id)
                .HasColumnName("PessoaId");

            modelBuilder.Entity<Pessoa>()
                .Property(c => c.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(150);

            modelBuilder.Entity<Pessoa>()
                .Property(c => c.Sexo);
                
            base.OnModelCreating(modelBuilder);
        }
    }
}
