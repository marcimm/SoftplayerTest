using AutoMapper;
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

        public TaxaJurosService(HttpClient httpClient, IOptions<AppSettings> settings, INotifier notifier, IMapper mapper)
            : base(notifier,  mapper)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.UrlTaxaJurosApi);
        }

        public async Task<decimal?> GetTaxaJuros()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/taxaJuros");

            if (TratarErrosResponse(response))
                return await DeserializarObjetoResponse<decimal?>(response);

            return null;
        }
    }
}
