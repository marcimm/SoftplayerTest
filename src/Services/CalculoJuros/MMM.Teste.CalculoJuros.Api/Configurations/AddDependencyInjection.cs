using Microsoft.Extensions.DependencyInjection;
using MMM.Test.Core.Notifications;
using MMM.Teste.CalculoJuros.Application.Services;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using System;
using System.Net.Http;

namespace MMM.Teste.CalculoJuros.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            // IoC           
            services.AddScoped<ICalculoJurossService, CalculoJurosService>();
            services.AddScoped<INotifier, Notifier>();

            // Resiliencia com Polly - Patterns Retry e Circuit Breaker
            services.AddHttpClient<ITaxaJurosService, TaxaJurosService>()
                .AddPolicyHandler(PollyExtensions.WaitAndTry())
                .AddTransientHttpErrorPolicy(
                    p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(20)));

            return services;
        }
    }

    #region PollyExtension
    public static class PollyExtensions
    {
        public static AsyncRetryPolicy<HttpResponseMessage> WaitAndTry()
        {
            var retry = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(3),
                    TimeSpan.FromSeconds(5)
                }, (outcome, timespan, retryCount, context) =>
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Retry Pattern com Polly - Wait and Retry - tentando pela {retryCount} vez!");
                    Console.ForegroundColor = ConsoleColor.White;
                });

            return retry;
        }
    }
    #endregion
}
