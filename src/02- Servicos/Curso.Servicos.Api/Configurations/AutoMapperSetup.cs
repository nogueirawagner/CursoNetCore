using AutoMapper;
using Curso.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Curso.Servicos.Api.Configurations
{
  public static class AutoMapperSetup
  {
    public static void AddAutoMapperSetup(this IServiceCollection services)
    {
      if (services == null) throw new ArgumentNullException(nameof(services));

      services.AddAutoMapper();

      // Registrar os Mapper dos contextos
      AutoMapperConfiguration.RegisterMappings();
    }
  }
}
