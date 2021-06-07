using Microsoft.AspNetCore.Mvc;
using MMM.Test.Core.Models;
using MMM.Test.Core.Notifications;
using MMM.Teste.CalculoJuros.Api.Controllers;
using MMM.Teste.CalculoJuros.Application.Services;
using MMM.Teste.CalculoJuros.Application.ViewModels;
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
        [ProducesResponseType(200, Type = typeof(ApiResponse<JurosCompostosViewModel>))]
        [ProducesResponseType(500, Type = typeof(ApiResponse<ErrorDetailsViewModel>))]
        public async Task<ActionResult<JurosCompostosViewModel>> GetTaxaJuros([FromQuery] decimal valorInicial,
            [FromQuery] int tempoMeses)
        {
            var response = await _calculoJurossService.CalcularJuros(valorInicial, tempoMeses);

            return CustomResponse(response);
        }

        [HttpGet]
        [Route("showmethecode")]
        [SwaggerOperation(summary: "Retorna Url do Github", Description = "Retorna Url do projeto no Github")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType(500, Type = typeof(ApiResponse<ErrorDetails>))]
        public ActionResult<string> GetGitHubUrl()
        {               
            return CustomResponse("Url Projeto: https://github.com/marcimm");
        }
    }
}
