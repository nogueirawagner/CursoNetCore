using Curso.WebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.WebApplication.Data
{
    public class CursoContext : DbContext
    {
        public CursoContext(DbContextOptions<CursoContext> options)
            :base(options)
        {
            
        }

        public DbSet<Evento> Evento { get; set; }
    }
}
