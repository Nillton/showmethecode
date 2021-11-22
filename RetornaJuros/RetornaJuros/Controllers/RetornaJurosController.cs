using Microsoft.AspNetCore.Mvc;
using RetornaJuros.Models;

namespace RetornaJuros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RetornaJurosController : ControllerBase
    {       
        [HttpGet]
        public IActionResult TaxaJuros()
        {
            TaxaJurosModels txJuros = new TaxaJurosModels();
            return Ok(txJuros);
        }
    }
}
