using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace conversor_de_moedas.models
{
    public class Currency
    {
        [JsonProperty("price")]
        public double CurrencyValue { get; set; }
        [JsonProperty("timestamp")]
        public int TimeStamp { get; set; }
     
    }
}
