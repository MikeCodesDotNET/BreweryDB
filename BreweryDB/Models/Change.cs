using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BreweryDB.Models
{
    public class Change
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public AttributeName AttributeName { get; set; }

      
        [JsonConverter(typeof(StringEnumConverter))]
        public Action Action { get; set; }
        
        public string SubAttributeName { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Action SubAction { get; set; }

        public string ChangeDate { get; set; }

        public SubAttribute SubAttribute { get; set; }
    }

    public enum Action
    {
        Edit,
        Insert,
        Delete
    }

    public enum AttributeName
    {
        Beer,
        Brewery,
        Location,
        Guild,
        Event
    }
}
