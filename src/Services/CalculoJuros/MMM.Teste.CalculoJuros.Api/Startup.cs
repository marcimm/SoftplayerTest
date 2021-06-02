using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MMM.Teste.CalculoJuros.Api.Configurations;
using MMM.Teste.CalculoJuros.Api.Extensions;

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
            services.AddControllers();
            services.AddHttpClient();
            services.AddSwaggerConfig();
            services.AddGzipCompressionConfig(Configuration);
            services.AddDependencyInjection();
            services.AddApiVersioningConfig();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseGzipCompressionConfig(Configuration);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => 
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MMM.Teste.CalculoJuros.Api v1"));
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
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
            app.UseSwaggerConfig();
        }
    }
}
