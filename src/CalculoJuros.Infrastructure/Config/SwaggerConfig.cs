using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoJuros.Infrastructure.Config
{
    public static class SwaggerConfig
    {
        public static void SwaggerConfigureServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Calcular Taxa de Juros API",
                    Description = "Projeto WEB API para calcular taxa de juros.",
                    Contact = new OpenApiContact
                    {
                        Name = "Junior Rocha",
                        Email = "juniorcesar.rocha@gmail.com",
                        Url = new Uri("https://github.com/juniorcesarrocha"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    }
                });
            });
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculo Juros API V1");
                c.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}
