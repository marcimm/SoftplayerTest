using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MMM.Teste.CalculoJuros.Api.Configurations;
using MMM.Teste.CalculoJuros.Api.Extensions;
using MMM.Teste.CalculoJuros.Application.AutoMapper;
using MMM.Teste.CalculoJuros.Models;
using Newtonsoft.Json.Serialization;

namespace MMM.Teste.CalculoJuros.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration);

            services.AddControllers();
            services.AddHttpClient();

            services.AddMvcConfig();
            services.AddApiVersioningConfig();
            services.AddSwaggerConfig();
            services.AddGzipCompressionConfig(Configuration);
            services.AddDependencyInjection();
            services.AddHealthChecksConfig(Configuration);
            services.AddAutoMapper(typeof(AutoMapperConfig));            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseGzipCompressionConfig(Configuration);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseSwaggerConfig(provider);

            app.UseSerilogConfig();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseGlobalizationSetup();
            app.UseAuthorization();
            app.UseMiddleware(typeof(ExceptionMiddleware));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHealthChecksConfig();
        }
    }
}
