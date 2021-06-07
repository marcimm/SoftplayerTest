using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MMM.Test.Core.Models;
using MMM.Test.Core.Notifications;
using MMM.Test.Core.Services.Identity;
using MMM.Teste.CalculoJuros.Api.Controllers;
using MMM.Teste.CalculoJuros.Application.Services;
using MMM.Teste.CalculoJuros.Application.ViewModels;
using System.Threading.Tasks;

namespace MMM.Test.Juros.Controllers.V2
{
    [ApiController]
    [Authorize]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/")]
    public class JurosController : BaseController
    {
        private readonly ICalculoJurossService _calculoJurossService;

        public JurosController(ICalculoJurossService calculoJurossService, INotifier notifier)
            : base(notifier)
        {
            _calculoJurossService = calculoJurossService;
        }

        /// <summary>
        /// Calcula juros compostos
        /// </summary>
        /// 
        [ClaimsAuthorize("Juros", "Ler")]
        [HttpGet]
        [Route("calculajuros")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<JurosCompostosViewModel>))]
        [ProducesResponseType(500, Type = typeof(ApiResponse<ErrorDetails>))]        
        public async Task<ActionResult<JurosCompostosViewModel>> GetTaxaJuros([FromQuery] decimal valorInicial,
            [FromQuery] int tempoMeses)
        {
            JurosCompostosViewModel response = await _calculoJurossService.CalcularJuros(valorInicial, tempoMeses);
            
            //return response;
            return CustomResponse(response);
        }
    }
}
