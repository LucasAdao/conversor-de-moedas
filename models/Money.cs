using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conversor_de_moedas.models
{
    public class Money
    {
        [JsonProperty("USD_BRL")]
       public Currency currency {  get; set; }  
    }
}
