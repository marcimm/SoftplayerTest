using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MMM.Test.Juros.Controllers.V1;
using MMM.Teste.CalculoJuros.Api.Configurations;
using MMM.Teste.CalculoJuros.Api.Extensions;
using MMM.Teste.CalculoJuros.Application.AutoMapper;
using MMM.Teste.CalculoJuros.Models;

namespace MMM.IntegrationTests.Configurations
{


    public class StartupCalculoJurosTest
    {
        public IConfiguration Configuration { get; }

        public StartupCalculoJurosTest(Microsoft.Extensions.Hosting.IHostingEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
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
            //services.AddHealthChecksConfig(Configuration);
            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddMvc()
                .AddApplicationPart(typeof(JurosController).Assembly);
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

            //app.UseSerilogConfig();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseGlobalizationSetup();
            app.UseAuthorization();
            app.UseMiddleware(typeof(ExceptionMiddleware));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // app.UseHealthChecksConfig();
        }
    }
}
