using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryDB.Interfaces
{
    public interface IFeature
    {
        string BeerId { get; set; }
        IBrewery Brewery { get; set; }
        IBeer Beer { get; set; }
        string Id { get; set; }
        int Week { get; set; }
        int Year { get; set; }
        string BreweryId { get; set; }
    }
}
