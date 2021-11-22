using Newtonsoft.Json;

namespace RetornaJuros.Models
{
    public class TaxaJurosModels
    {        
        [JsonProperty("TaxaJuros")]        
        public double TaxaJuros { get; set; } = 0.01;
    }
}
