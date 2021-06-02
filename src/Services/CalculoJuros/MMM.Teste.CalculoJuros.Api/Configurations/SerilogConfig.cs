using Microsoft.AspNetCore.Builder;
using Serilog;

namespace MMM.Teste.CalculoJuros.Api.Configurations
{
    public static class SerilogConfig
    {
        public static IApplicationBuilder UseSerilogConfig(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging(options =>
            {
                options.GetLevel = (httpContext, elapsed, ex) => Serilog.Events.LogEventLevel.Debug;
            });

            return app;
        }
    }
}
