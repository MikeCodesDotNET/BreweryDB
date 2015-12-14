using BreweryDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryDB.Models
{
    public class Event : IEvent
    {

        public Event(Country country, Images images)
        {
            Country = country;
            Images = images;
        }

        public string Id { get; set; }
        public string Year { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string TypeDisplay { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Time { get; set; }
        public string VenueName { get; set; }
        public string StreetAddress { get; set; }
        public string Locality { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string CountryIsoCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public string StatusDisplay { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public ICountry Country { get; set; }
        public string Price { get; set; }
        public IImages Images { get; set; }
        public string ExtendedAddress { get; set; }
    }
}
