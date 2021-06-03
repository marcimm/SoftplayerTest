using Microsoft.Extensions.DependencyInjection;
using MMM.Teste.CalculoJuros.Application.Services;

namespace MMM.Teste.CalculoJuros.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            // IoC
            services.AddHttpClient<ITaxaJurosService, TaxaJurosService>();
            services.AddScoped<ICalculoJurossService, CalculoJurossService>();
 
            return services;
        }
    }
}
