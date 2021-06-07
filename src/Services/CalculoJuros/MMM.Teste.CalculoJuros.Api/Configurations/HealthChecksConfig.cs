using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;

namespace MMM.Teste.CalculoJuros.Api.Configurations
{
    public static class HealthChecksConfig
    {
        public static IServiceCollection AddHealthChecksConfig(this IServiceCollection services, IConfiguration configuration)
        {
            // para mapemanto das urls no container:
            string api01Url = configuration.GetValue<string>("UrlTaxaJurosApi");
            string api02Url = configuration.GetValue<string>("UrlCalculoJurosApi");

            services.AddHealthChecks()
                .AddCheck("Api-02_CalculoJuros", () => HealthCheckResult.Healthy("Api OK!"), tags: new[] { "API" })
                .AddUrlGroup(new Uri(api01Url), "Api-01_TaxaJuros", tags: new[] { "API" })
                .AddSqlServer(configuration.GetConnectionString("IdentitySqlServer"), null, "SQL-Server_IDENTITY", tags: new[] { "DB" });

            services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(15); //time in seconds between check
                opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks
                opt.SetApiMaxActiveRequests(1); //api requests concurrency

                opt.AddHealthCheckEndpoint("Softplayer Apis", api02Url + "/healthz"); // map health check api
            })
            .AddInMemoryStorage();

            return services;
        }

        public static IApplicationBuilder UseHealthChecksConfig(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/healthz", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                // map healthcheck ui endpoing - default is /healthchecks-ui/
                endpoints.MapHealthChecksUI();
            });

            return app;
        }
    }
}
