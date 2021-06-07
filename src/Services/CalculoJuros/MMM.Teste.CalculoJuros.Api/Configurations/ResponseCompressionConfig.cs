using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Compression;

namespace MMM.Teste.CalculoJuros.Api.Configurations
{
    public static class ResponseCompressionConfig
    {
        public static IServiceCollection AddGzipCompressionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            if (ResponseCompression(configuration))
            {
                services.AddResponseCompression(options =>
                {
                    options.EnableForHttps = true;
                    options.Providers.Add<GzipCompressionProvider>();
                });
                services.Configure<GzipCompressionProviderOptions>(options =>
                {
                    options.Level = CompressionLevel.Fastest;
                });
            }

            return services;
        }

        private static bool ResponseCompression(IConfiguration configuration)
        {
            return configuration.GetSection("ResponseCompression").Get<bool>();
        }

        public static IApplicationBuilder UseGzipCompressionConfig(this IApplicationBuilder app, IConfiguration configuration)
        {
            if (ResponseCompression(configuration))
                app.UseResponseCompression();

            return app;
        }
    }
}
