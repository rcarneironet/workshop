using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Contoso.Store.API.Configurations
{
    public static class ApiConfig
    {
        public static void ConfigurateSwaggerSetup(IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s => s.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Version = "1.0",
                    Title = "API Workshop Academia",
                    Description = "API do Contoso Store"
                }));
        }

        public static void UseSwaggerSetup(IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contoso API");
            });
        }
    }
}
