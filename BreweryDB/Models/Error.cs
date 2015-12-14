using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BreweryDB.Models
{
    public class Error
    {
        [JsonProperty("ErrorMessage")]
        public string Message { get; set; }
        public string Status { get; set; }
    }
}
