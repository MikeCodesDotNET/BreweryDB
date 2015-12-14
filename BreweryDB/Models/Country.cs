using BreweryDB.Interfaces;

namespace BreweryDB.Models
{
    public class Country : ICountry
    {
        public string CountryIsoCode { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string IsoThree { get; set; }
        public int NumberCode { get; set; }
        public string CreateDate { get; set; }
    }
}