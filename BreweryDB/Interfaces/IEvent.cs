using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryDB.Interfaces
{
    public interface IEvent
    {
        string Id { get; set; }
        string Year { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Type { get; set; }
        string TypeDisplay { get; set; }
        string StartDate { get; set; }
        string EndDate { get; set; }
        string Time { get; set; }
        string VenueName { get; set; }
        string StreetAddress { get; set; }
        string Locality { get; set; }
        string Region { get; set; }
        string PostalCode { get; set; }
        string CountryIsoCode { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
        string Website { get; set; }
        string Phone { get; set; }
        string Status { get; set; }
        string StatusDisplay { get; set; }
        string CreateDate { get; set; }
        string UpdateDate { get; set; }
        ICountry Country { get; set; }
        string Price { get; set; }
        IImages Images { get; set; }
        string ExtendedAddress { get; set; }
    }
}
