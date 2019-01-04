using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Curso.WebApplication.Models
{
    public class CursoWebApplicationContext : DbContext
    {
        public CursoWebApplicationContext (DbContextOptions<CursoWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Curso.WebApplication.Models.Evento> Evento { get; set; }
    }
}
