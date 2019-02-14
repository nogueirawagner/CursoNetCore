using Curso.Domain.IRepositories;
using Curso.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Curso.Data.IoC
{
    public class NativeInjectorBootstraper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Infra - Repositories
            services.AddScoped<IEventoRepository, EventoRepository>();

            // Infra - Data
            services.AddScoped<DbContext>();
        }
    }
}
