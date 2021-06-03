using System.Threading.Tasks;

namespace MMM.Teste.CalculoJuros.Application.Services
{
    public interface ITaxaJurosService
    {
        Task<double?> GetTaxaJuros();
    }
}
