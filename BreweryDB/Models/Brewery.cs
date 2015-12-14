using System.Collections.Generic;
using BreweryDB.Interfaces;

namespace BreweryDB.Models
{
    public class Brewery : IBrewery
    {
        public Brewery(List<Location> locations)
        {
            Locations = locations as List<Location>;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string IsOrganic { get; set; }
        public string Status { get; set; }
        public string StatusDisplay { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public List<Location> Locations { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Established { get; set; }
        public IImages Image { get; set; }
    }
}