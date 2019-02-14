using Curso.Domain.Models;
using Curso.Infra.Data.Extensions;
using Curso.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Curso.Infra.Data.Context
{
    public class ContextDb : DbContext
    {
        public DbSet<Evento> Evento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new EventoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
