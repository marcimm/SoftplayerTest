using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace MMM.Tests.Identity.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Márcio MM - API Identity",
                    Description = "Api para gerenciamento de Usuários com Identity",
                    Version = "1.0",
                    Contact = new OpenApiContact
                    {
                        Name = "Márcio Molina Morassutti",
                        Email = "marcio.molina.m@gmail.com"
                    }
                });

            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.RoutePrefix = String.Empty;
            });

            return app;
        }
    }
}
