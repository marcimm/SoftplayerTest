using MMM.Test.Core.Notifications;
using MMM.Teste.CalculoJuros.Models;
using MMM.Teste.CalculoJuros.Validations;
using System.Threading.Tasks;

namespace MMM.Teste.CalculoJuros.Application.Services
{
    public class CalculoJurosService : ServiceBase, ICalculoJurossService
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public CalculoJurosService(ITaxaJurosService taxaJurosService, INotifier notifier)
            : base(notifier)
        {
            _taxaJurosService = taxaJurosService;
        }

        public async Task<double?> CalcularJuros(decimal capitalAplicado, int tempoMeses)
        {
            double? taxaJuros = await _taxaJurosService.GetTaxaJuros();

            Juros juros = new Juros(capitalAplicado, taxaJuros.Value, tempoMeses);

            if (!ValidateProperties(new JurosValidation(), juros))
                return null;


            return juros.CalcularJurosCompostos();
        }
    }
}
