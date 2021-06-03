using System.Threading.Tasks;

namespace MMM.Teste.CalculoJuros.Application.Services
{
    public interface ICalculoJurossService
    {
        Task<double> CalcularJuros(decimal capitalAplicado, int tempoMeses);
    }
}
