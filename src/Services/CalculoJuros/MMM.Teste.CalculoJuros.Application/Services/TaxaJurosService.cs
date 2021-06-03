using Microsoft.Extensions.Options;
using MMM.Test.Core.Notifications;
using MMM.Teste.CalculoJuros.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MMM.Teste.CalculoJuros.Application.Services
{
    public class TaxaJurosService : ServiceBase, ITaxaJurosService
    {
        private readonly HttpClient _httpClient;

        public TaxaJurosService(HttpClient httpClient, IOptions<AppSettings> settings, INotifier notifier)
            : base(notifier)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.UrlTaxaJurosApi);
        }

        public async Task<double?> GetTaxaJuros()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/taxaJuros");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<double>(response);
        }
    }
}
