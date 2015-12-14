using BreweryDB.Interfaces;
using System.Collections.Generic;

namespace BreweryDB.Models
{
    public class Fermentable : IFermentable
    {
        public Fermentable(List<Characteristic> characteristics, Srm srm, Country country)
        {
            Characteristics = characteristics;
            Srm = srm;
            Country = country;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string CategoryDisplay { get; set; }
        public string Description { get; set; }
        public string CountryOfOrigin { get; set; }
        public int? SrmId { get; set; }
        public int? SrmPrecise { get; set; }
        public double? MoistureContent { get; set; }
        public double? DryYield { get; set; }
        public double? Potential { get; set; }
        public double? Protein { get; set; }
        public int? MaxInBatch { get; set; }
        public string RequiresMashing { get; set; }
        public List<Characteristic> Characteristics { get; set; }
        public ISrm Srm { get; set; }
        public ICountry Country { get; set; }
        public double? CoarseFineDifference { get; set; }
        public int? DiastaticPower { get; set; }
    }
}
