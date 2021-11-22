using ApiCalculaJuros.Models;
using CalculaJuros.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;


namespace ApiCalculaJuros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        //CalculaJurosModel valores = new CalculaJurosModel();

        [HttpGet]
        public async Task<string> GetExternalResponse()
        {
            HttpClient client = new HttpClient();
            //string url = "https://localhost:44353/RetornaJuros";
            string url = "https://localhost:5001/RetornaJuros";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;        
        }

        [HttpPost]
        public async Task<IActionResult> CalculaJuros([FromHeader] CalculaJurosModel valorIni, [FromHeader] CalculaJurosModel valorMes)
        {
            CalculaJurosService cjServ = new CalculaJurosService();

            var vi = valorIni.ValorInicial;
            var vm = valorMes.Meses;
            double valorfinal;
            var result = await GetExternalResponse();

            TaxaJ taxa = JsonConvert.DeserializeObject<TaxaJ>(result);

            valorfinal =  cjServ.TaxaJurosComposto(vi, vm, taxa.TaxaJurosCalc);

            return Ok(new
            {
                Valor_Com_Juros = valorfinal.ToString("f2")
            });
        }


        //[HttpPost]
        //public async Task<IActionResult> CalculaJuros([FromHeader]CalculaJurosModel valorIni, [FromHeader]CalculaJurosModel valorMes)
        //{
        //    CalculaJurosService cjServ = new CalculaJurosService();

        //    var vi  = valorIni.ValorInicial;
        //    var vm = valorMes.Meses;
        //    double valorfinal = 0;
        //    var result = await GetExternalResponse();

        //    TaxaJ taxa = JsonConvert.DeserializeObject<TaxaJ>(result);

        //    cjServ.TaxaJurosComposto(vi, vm, out valorfinal, taxa.TaxaJurosCalc);

        //    return Ok(new
        //    {
        //        Valor_Com_Juros = valorfinal.ToString("f2")
        //    });
        //}

        //[HttpPost]
        //public async Task<IActionResult> CalculaJuros([FromHeader] CalculaJurosModel valores)
        //{
        //    CalculaJurosService cjServ = new CalculaJurosService();
        //    double valorfinal = 0;
        //    var result = await GetExternalResponse();

        //    TaxaJ taxa = JsonConvert.DeserializeObject<TaxaJ>(result);           

        //    cjServ.TaxaJurosComposto(valores, out valorfinal, taxa.TaxaJurosCalc);

        //    return Ok(new
        //    {
        //        Valor_Com_Juros = valorfinal.ToString("f2")
        //    });
        //}
    }

}
