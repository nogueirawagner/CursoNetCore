﻿using EFCore.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Evento
            modelBuilder.Entity<Evento>()
                .ToTable("Evento");

            modelBuilder.Entity<Evento>()
                .HasKey(s => s.Id);

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

            modelBuilder.Entity<Evento>()
                .HasOne(e => e.Categoria)
                .WithMany(c => c.Eventos)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion Evento

            #region Endereco

            modelBuilder.Entity<Endereco>()
                .ToTable("Endereco");

            modelBuilder.Entity<Endereco>()
                .HasKey(s => s.Id);

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
                .Property(s => s.Id);

            modelBuilder.Entity<Pessoa>()
                .ToTable("Pessoa");

            modelBuilder.Entity<Pessoa>()
                .Property(s => s.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            modelBuilder.Entity<Pessoa>()
                .Property(s => s.CPF)
                .HasColumnType("varchar(11)")
                .IsRequired();

            modelBuilder.Entity<Pessoa>()
                .Property(s => s.Idade)
                .IsRequired();

            modelBuilder.Entity<Pessoa>()
                .Property(s => s.Sexo)
                .IsRequired();

            #endregion Pessoa

            #region Categoria
            modelBuilder.Entity<Categoria>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Categoria>()
                .Property(s => s.Nome)
                .HasColumnType("varchar(150");

            //modelBuilder.Entity<Categoria>()
            //    .HasMany(c => c.Eventos);

            #endregion

            //#region Blog

            //modelBuilder.Entity<Blog>()
            //    .HasOne(b => b.Posts)
            //    .WithOne(p => p.Blog)
            //    .HasForeignKey<Post>(b => b.BlogId);

            //#endregion

            //#region Post
            //#endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
