using Microsoft.AspNetCore.Mvc;
using MMM.Teste.CalculoJuros.Api.Controllers;

namespace MMM.Test.Juros.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/")]
    public class JurosController : BaseController
    {

        public JurosController()
        {

        }

        /// <summary>
        /// Calcula juros compostos
        /// </summary>
        [HttpGet]
        [Route("calculajuros")]
        public ActionResult<float> GetTaxaJuros()
        {
            return 2;
        }
    }
}
