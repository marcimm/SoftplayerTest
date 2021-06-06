using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MMM.Test.Core.Services.Identity;
using MMM.Tests.Identity.Api.Configurations;
using MMM.Tests.Identity.Api.Context;
using MMM.Tests.Identity.Api.Database;

namespace MMM.Tests.Identity.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
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
            services.Configure<TokenAppSettings>(Configuration.GetSection("AppSettings"));

            services.AddIdentityConfiguration(Configuration);

            services.AddSwaggerConfiguration();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
            ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            // Testes -> Executar Migrations para atualizar DB  
            db.Database.Migrate();
            ApplicationDbInitializer.SeedUsers(userManager);

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwaggerConfiguration();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
