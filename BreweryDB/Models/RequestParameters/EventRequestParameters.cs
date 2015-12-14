using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryDB.Models.RequestParameters
{
    public class EventRequestParameters
    {
        public static readonly string Page = "p";
        public static readonly string Year = "year";
        public static readonly string Name = "name";
        public static readonly string Type = "type";
        public static readonly string Locality = "locality";
        public static readonly string Region = "region";
        public static readonly string CountryIsoCode = "countryIsoCode";
        public static readonly string Since = "since";
        public static readonly string Status = "status";
        public static readonly string HasImage = "hasImage";
    }
}
