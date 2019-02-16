using AutoMapper;
using Curso.Application.Interfaces;
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
            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(s => new Mapper(s.GetRequiredService<IConfigurationProvider>(), s.GetServices));
            services.AddScoped<IEventoServices, IEventoServices>();

            // Infra - Repositories
            services.AddScoped<IEventoRepository, EventoRepository>();

            // Infra - Data
            services.AddScoped<DbContext>();
        }
    }
}
