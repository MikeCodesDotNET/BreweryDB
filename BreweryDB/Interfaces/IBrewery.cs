using System.Collections.Generic;
using BreweryDB.Models;

namespace BreweryDB.Interfaces
{
    public interface IBrewery
    { 
        string Id { get; set; }
        string Name { get; set; }
        string IsOrganic { get; set; }
        string Status { get; set; }
        string StatusDisplay { get; set; }
        string CreateDate { get; set; }
        string UpdateDate { get; set; }
        List<Location> Locations { get; set; }
        string Description { get; set; }
        string Website { get; set; }
        string Established { get; set; }
        IImages Image { get; set; }
    }
}