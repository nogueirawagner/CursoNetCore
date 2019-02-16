using AutoMapper;
using Curso.Data.IoC;
using Curso.Infra.Identity.Data;
using Curso.Infra.Jwt.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

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

      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(bearerOptions =>
      {
        bearerOptions.RequireHttpsMetadata = false;
        bearerOptions.SaveToken = true;

        var paramsValidation = bearerOptions.TokenValidationParameters;

        paramsValidation.IssuerSigningKey = SigningCredentialsConfiguration.Key;
        paramsValidation.ValidAudience = tokenConfigurations.Audience;
        paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

        paramsValidation.ValidateIssuerSigningKey = true;
        paramsValidation.ValidateLifetime = true;
        paramsValidation.ClockSkew = TimeSpan.Zero;
      });

      services.AddAuthorization(options =>
      {
        options.AddPolicy("Clientes", policy => policy.RequireRole("Cliente"));

        options.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                  .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                  .RequireAuthenticatedUser().Build());
      });

      services.AddAutoMapper();
      services.AddSingleton(tokenConfigurations);

      // Configurações do Swagger
      //services.AddSwaggerGen(s =>
      //{
      //  s.SwaggerDoc("v1", new Info
      //  {
      //    Version = "v1",
      //    Title = "Exs API",
      //    Description = "API do projeto Exs",
      //    TermsOfService = "Nenhum",
      //    Contact = new Contact { Name = "API Exs", Email = "nogueirawagner@gmail.com", Url = "http://exs.net.br/" },
      //    License = new License { Name = "CC BY-NC-ND", Url = "https://creativecommons.org/licenses/by-nc-nd/4.0/legalcode" }
      //  });

      //  s.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
      //});

      //services.ConfigureSwaggerGen(opt =>
      //{
      //  opt.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
      //});



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
