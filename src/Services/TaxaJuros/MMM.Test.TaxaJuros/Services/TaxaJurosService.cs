using Microsoft.Extensions.Configuration;

namespace MMM.Test.TaxaJuros.Api.Services
{
    public class TaxaJurosService : ITaxaJurosService
    {
        private readonly IConfiguration _configuration;

        public TaxaJurosService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public float GetTaxaJurosValor()
        {
            return _configuration.GetValue<float>("TaxaJuros");
        }
    }
}
