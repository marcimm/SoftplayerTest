using Microsoft.AspNetCore.Mvc;
using MMM.Test.TaxaJuros.Api.Services;

namespace MMM.Test.TaxaJuros.Controllers
{
    [ApiController]
    [Route("[action]/")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class TaxaJurosController : Controller
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public TaxaJurosController(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        /// <summary>
        /// Retorna taxa de juros atual
        /// </summary>
        [HttpGet]
        [ActionName("taxaJuros")]
        public ActionResult<float> GetTaxaJuros()
        {
            return _taxaJurosService.GetTaxaJurosValor();
        }
    }
}
