using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Data.IoC;
using Curso.Infra.Identity.Data;
using Exs.Infra.Identity.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Curso.Servicos.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // Contexto do EF para o Identity
      services.AddDbContext<IdentityContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("MeuNoteConnection")));

      // Configurações de Autenticação, Autorização e JWT
      var tokenConfigurations = new TokenDescriptor();
      new ConfigureFromConfigurationOptions<TokenDescriptor>(
              Configuration.GetSection("JwtTokenOptions"))
          .Configure(tokenConfigurations);

      services.AddSingleton(tokenConfigurations);

      services.AddMvc();

      RegisterServices(services);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();
    }

    private static void RegisterServices(IServiceCollection services)
    {
      NativeInjectorBootstraper.RegisterServices(services);
    }
  }
}
