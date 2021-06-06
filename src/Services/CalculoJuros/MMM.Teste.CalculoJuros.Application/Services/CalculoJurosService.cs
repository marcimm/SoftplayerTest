using AutoMapper;
using MMM.Test.Core.Notifications;
using MMM.Teste.CalculoJuros.Application.ViewModels;
using MMM.Teste.CalculoJuros.Models;
using MMM.Teste.CalculoJuros.Validations;
using System.Threading.Tasks;

namespace MMM.Teste.CalculoJuros.Application.Services
{
    public class CalculoJurosService : ServiceBase, ICalculoJurossService
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public CalculoJurosService(ITaxaJurosService taxaJurosService, INotifier notifier, IMapper mapper)
            : base(notifier, mapper)
        {
            _taxaJurosService = taxaJurosService;
        }

        public async Task<JurosCompostosViewModel> CalcularJuros(decimal valorInicial, int tempoMeses)
        {
            decimal? taxaJuros = await _taxaJurosService.GetTaxaJuros();

            JurosCompostos juros = new JurosCompostos(valorInicial, taxaJuros.Value, tempoMeses);

            if (!ValidateProperties(new JurosCompostosValidation(), juros))
                return null;

            JurosCompostosViewModel result = _mapper.Map<JurosCompostosViewModel>(juros);

            return result;

        }
    }
}
