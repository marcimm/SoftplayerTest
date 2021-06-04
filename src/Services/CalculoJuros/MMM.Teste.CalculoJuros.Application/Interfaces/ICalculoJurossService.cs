using MMM.Teste.CalculoJuros.Application.ViewModels;
using System.Threading.Tasks;

namespace MMM.Teste.CalculoJuros.Application.Services
{
    public interface ICalculoJurossService
    {
        Task<JurosCompostosViewModel> CalcularJuros(decimal valorInicial, int tempoMeses);
    }
}
