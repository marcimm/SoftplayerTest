using MMM.Teste.CalculoJuros.Models;
using System.Threading.Tasks;

namespace MMM.Teste.CalculoJuros.Application.Services
{
    public class CalculoJurossService : ServiceBase, ICalculoJurossService
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public CalculoJurossService(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        public async Task<double> CalcularJuros(decimal capitalAplicado, int tempoMeses)
        {
            double? taxaJuros = await _taxaJurosService.GetTaxaJuros();

            Juros jurosCompostos = new Juros(capitalAplicado, taxaJuros.Value, tempoMeses);


            return jurosCompostos.CalcularJurosCompostos();
        }
    }
}
