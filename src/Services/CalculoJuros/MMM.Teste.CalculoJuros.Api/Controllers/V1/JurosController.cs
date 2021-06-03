using Microsoft.AspNetCore.Mvc;
using MMM.Teste.CalculoJuros.Api.Controllers;
using MMM.Teste.CalculoJuros.Application.Services;
using System.Threading.Tasks;

namespace MMM.Test.Juros.Controllers.V1
{
    [ApiController]
    [ApiVersion("1", Deprecated = true)]
    [Route("v{version:apiVersion}/")]
    public class JurosController : BaseController
    {
        private readonly ICalculoJurossService _calculoJurossService;

        public JurosController(ICalculoJurossService calculoJurossService)
        {
            _calculoJurossService = calculoJurossService;
        }



        /// <summary>
        /// Calcula juros compostos
        /// </summary>
        [HttpGet]
        [Route("calculajuros")]
        public async Task<ActionResult<double>> GetTaxaJuros([FromQuery] decimal capitalAplicado,
            [FromQuery] int tempoMeses)
        {
            var response = await _calculoJurossService.CalcularJuros(capitalAplicado, tempoMeses);

            return response;
        }
    }
}
