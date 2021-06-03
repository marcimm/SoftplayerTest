using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MMM.Teste.CalculoJuros.Api.Configurations;
using MMM.Teste.CalculoJuros.Api.Extensions;
using MMM.Teste.CalculoJuros.Models;

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
            services.AddApiVersioningConfig(); 
            services.AddControllers();
            services.AddHttpClient();
            services.AddSwaggerConfig();
            services.AddGzipCompressionConfig(Configuration);
            services.AddDependencyInjection();

            services.Configure<AppSettings>(Configuration);
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
        }
    }
}
