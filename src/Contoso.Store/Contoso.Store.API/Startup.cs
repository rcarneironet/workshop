using Contoso.Store.Infrastructure.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddSwaggerGen(s =>
            s.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Version = "1.0",
                Title = "API Workshop Academia",
                Description = "API do Contoso Store"
            }));

            /*
             * Transient -> um novo objeto é sempre criado, uma nova instância é sempre provida para cada request/serviço
             * Scoped -> Um mesmo objeto dentro de um request, mas diferente entre multiplos requests
             * Singleton (padrão de projeto) -> Os objetos ficam na memoria enquanto o sistema estiver no ar
             */

            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            new RootBootstrapper().BootStrapperRegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors("CorsPolicy");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Observabilidade");
            });
        }
    }
}
