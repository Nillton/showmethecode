using Newtonsoft.Json;

namespace ApiCalculaJuros.Models
{
    public class CalculaJurosModel
    {          
        public double ValorInicial { get; set; }        
        public int Meses { get; set; }
    }

    [JsonObject("TaxaJuros")]
    public class TaxaJ 
    { 
       [JsonProperty("taxaJuros")]
        public double TaxaJurosCalc { get; set; }    
    }   

}
