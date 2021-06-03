using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;

namespace MMM.Teste.CalculoJuros.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGenNewtonsoftSupport();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Márcio MM - API 2",
                    Description = "Api de teste - Calcula Juros",
                    Version = "1.0",
                    Contact = new OpenApiContact
                    {
                        Name = "Márcio Molina Morassutti",
                        Email = "marcio.molina.m@gmail.com"
                    }
                });

                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Márcio MM - API 2",
                    Description = "Api de teste - Calcula Juros",
                    Version = "2.0",
                    Contact = new OpenApiContact
                    {
                        Name = "Márcio Molina Morassutti",
                        Email = "marcio.molina.m@gmail.com"
                    }
                });

                //options.DocInclusionPredicate((docName, description) => true); // endpoints no mesmo arquivo

                options.EnableAnnotations();
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
                options.CustomSchemaIds(obj => obj.FullName);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    options.RoutePrefix = String.Empty;
                }
                options.DocExpansion(DocExpansion.List);
            });

            return app;
        }
    }
}
