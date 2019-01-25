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
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Evento
            modelBuilder.Entity<Evento>()
                .ToTable("Evento");

            modelBuilder.Entity<Evento>()
                .Property(s => s.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            modelBuilder.Entity<Evento>()
              .Property(s => s.Descricao)
              .HasColumnType("varchar(150)")
              .IsRequired();

            modelBuilder.Entity<Evento>()
                .Property(s => s.Valor)
                .HasColumnType("decimal(15,2)")
                .IsRequired();
            #endregion Evento

            #region Endereco

            modelBuilder.Entity<Endereco>()
                .ToTable("Enderecos");

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Logradouro)
                       .IsRequired()
                       .HasColumnType("varchar(150)");

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Numero)
                .IsRequired()
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Bairro)
                .IsRequired()
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Endereco>()
                .Property(e => e.CEP)
                .IsRequired()
                .HasColumnType("varchar(8)");

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Complemento)
                .HasColumnType("varchar(100)");

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Cidade)
                .IsRequired()
                .HasColumnType("varchar(100)");

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Estado)
                .IsRequired()
                .HasColumnType("varchar(100)");
            #endregion Endereco

            #region Pessoa
            modelBuilder.Entity<Pessoa>()
                .ToTable("Pessoa");

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            modelBuilder.Entity<Pessoa>()
                .Property(s => s.Sexo)
                .IsRequired();
            
            #endregion Pessoa

            base.OnModelCreating(modelBuilder);
        }
    }
}
