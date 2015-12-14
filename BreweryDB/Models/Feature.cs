using BreweryDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryDB.Models
{
    public class Feature : IFeature
    {
        public Feature(Beer beer, Brewery brewery)
        {
            Beer = beer;
            Brewery = brewery;
        }

        public string BeerId { get; set; }
        public IBrewery Brewery { get; set; }
        public IBeer Beer { get; set; }
        public string Id { get; set; }
        public int Week { get; set; }
        public int Year { get; set; }
        public string BreweryId { get; set; }
    }
}
