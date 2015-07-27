using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BreweryDB.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Beer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("abv")]
        public string Abv { get; set; }

        [JsonProperty("glasswareId")]
        public int GlasswareId { get; set; }

        [JsonProperty("srmId")]
        public int SrmId { get; set; }

        [JsonProperty("availableId")]
        public int AvailableId { get; set; }

        [JsonProperty("styleId")]
        public int StyleId { get; set; }
        public string IsOrganic { get; set; }
        public string Status { get; set; }
        public string StatusDisplay { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public Glass Glass { get; set; }
        public Srm Srm { get; set; }
        public Available Available { get; set; }
        public Style Style { get; set; }
        public List<Brewery> Breweries {get; set;}
        public Labels Labels {get; set;}
        public string ServingTemperature {get; set;}
           
        public string Brewery
        {
            get
            {
                if (Breweries != null)
                {
                    return Breweries[0].Name;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
