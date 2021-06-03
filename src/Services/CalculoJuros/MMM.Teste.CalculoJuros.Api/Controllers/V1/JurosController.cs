using Microsoft.AspNetCore.Mvc;
using MMM.Test.Core.Models;
using MMM.Test.Core.Notifications;
using MMM.Teste.CalculoJuros.Api.Controllers;
using MMM.Teste.CalculoJuros.Application.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace MMM.Test.Juros.Controllers.V1
{
    [ApiController]
    [ApiVersion("1", Deprecated = true)]
    [Route("v{version:apiVersion}/")]
    public class JurosController : BaseController
    {
        private readonly ICalculoJurossService _calculoJurossService;

        public JurosController(ICalculoJurossService calculoJurossService, INotifier notifier) 
            : base(notifier)
        {
            _calculoJurossService = calculoJurossService;
        }

        [HttpGet]
        [Route("calculajuros")]
        [SwaggerOperation(summary: "Retorna cálculo de juros compostos", Description = "Consulta taxa de juros na API 1 e calcula os juros compostos")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<double>))]
        [ProducesResponseType(500, Type = typeof(ApiResponse<ErrorDetails>))]
        public async Task<ActionResult<double>> GetTaxaJuros([FromQuery] decimal capitalAplicado,
            [FromQuery] int tempoMeses)
        {
            var response = await _calculoJurossService.CalcularJuros(capitalAplicado, tempoMeses);

            return CustomResponse(response);
        }
    }
}
