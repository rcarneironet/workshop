using Contoso.Store.API.Configurations;
using Contoso.Store.Infrastructure.IoC;
using Contoso.Store.Shared.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace Contoso.Store.API
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
            services.AddControllers();
            services.AddOptions();
            //Swagger
            ApiConfig.ConfigurateSwaggerSetup(services);
            //Services
            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            /*
            * Transient -> um novo objeto é sempre criado, uma nova instância é sempre provida para cada request/serviço
            * Scoped -> Um mesmo objeto dentro de um request, mas diferente entre multiplos requests
            * Singleton (padrão de projeto) -> Os objetos ficam na memoria enquanto o sistema estiver no ar
            */
            new RootBootstrapper().BootStrapperRegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ApiConfig.UseSwaggerSetup(app);
        }
    }
}
