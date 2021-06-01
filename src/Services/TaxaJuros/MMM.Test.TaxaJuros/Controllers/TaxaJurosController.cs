using Microsoft.AspNetCore.Mvc;
using MMM.Test.TaxaJuros.Services;

namespace MMM.Test.TaxaJuros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : Controller
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public TaxaJurosController(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        /// <summary>
        /// Retorna taxa de juros
        /// </summary>
        [HttpGet]
        [ActionName("get")]
        public ActionResult<float> GetTaxaJuros()
        {
            return _taxaJurosService.GetTaxaJurosValor();
        }
    }
}
