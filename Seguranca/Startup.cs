using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seguranca.Data;
using Seguranca.Models;
using Seguranca.Services;
using System;

namespace Seguranca
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
            #region 
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer
                (Configuration.GetConnectionString("MeuNoteConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults
                .AuthenticationScheme)
                .AddFacebook(faceOptions =>
                {
                    faceOptions.AppId =
                    Configuration["Authentication:Facebook:AppId"];
                    faceOptions.AppSecret =
                    Configuration["Authentication:Facebook:AppSecret"];
                })
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId
                    = Configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret
                    = Configuration["Authentication:Google:ClientSecret"];
                })
                .AddMicrosoftAccount(microsoftOptions =>
                {
                    microsoftOptions.ClientId
                    = Configuration["Authentication:Microsoft:ClientId"];
                    microsoftOptions.ClientSecret
                    = Configuration["Authentication:Microsoft:ClientSecret"];
                })
                .AddTwitter(twitterOptions =>
                {
                    twitterOptions.ConsumerKey
                    = Configuration["Authentication:Twitter:ConsumerKey"];
                    twitterOptions.ConsumerSecret
                    = Configuration["Authentication:Twitter:ConsumerSecret"];
                });

            services.Configure<IdentityOptions>(options =>
            {
                // Configuraçoes de senha
                options.Password.RequireDigit = true; // Requer digíto?
                options.Password.RequiredLength = 6; // Qual o tamanho mínimo?
                options.Password.RequireNonAlphanumeric = false; // Requer caractere especial?
                options.Password.RequireUppercase = false; // Requer letra maiúscula?
                options.Password.RequireLowercase = false; // Requer letra minúscula?

                // Configuraçoes de bloqueio
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Tempo de bloqueio.
                options.Lockout.MaxFailedAccessAttempts = 5; // Tentativas máximas de senha incorreta.

                // Configuraçoes do usuario
                options.User.RequireUniqueEmail = true; // Requer e-mail único?
            });
            #endregion
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AcessoHome", policy => policy.RequireClaim("HomeClaim"));
                options.AddPolicy("AcessoAccount", policy => policy.RequireClaim("AccountClaim"));
                options.AddPolicy("AcessoManage", policy => policy.RequireClaim("ManageClaim"));
            });
            #region 
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
