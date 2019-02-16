using AutoMapper;
using Curso.Application.Interfaces;
using Curso.Application.Services;
using Curso.Domain.Interfaces;
using Curso.Domain.IRepositories;
using Curso.Infra.Data.Context;
using Curso.Infra.Data.Repository;
using Curso.Infra.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Curso.Data.IoC
{
  public class NativeInjectorBootstraper
  {
    public static void RegisterServices(IServiceCollection services)
    {
      // Application
      services.AddSingleton(Mapper.Configuration);
      services.AddScoped<IMapper>(s => new Mapper(s.GetRequiredService<IConfigurationProvider>(), s.GetServices));
      services.AddScoped<IEventoServices, EventoServices>();

      // Infra - Repositories
      services.AddScoped<IEventoRepository, EventoRepository>();

      // Infra - Data
      services.AddScoped<ContextDb>();

      // Infra - Identity
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      services.AddScoped<IUser, AspNetUser>();
    }
  }
}
