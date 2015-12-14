using BreweryDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryDB.Interfaces
{
    public interface IFermentable
    {
        string Id { get; set; }
        string Name { get; set; }
        string Category { get; set; }
        string CategoryDisplay { get; set; }
        string Description { get; set; }
        string CountryOfOrigin { get; set; }
        int? SrmId { get; set; }
        int? SrmPrecise { get; set; }
        double? MoistureContent { get; set; }
        double? DryYield { get; set; }
        double? Potential { get; set; }
        double? Protein { get; set; }
        int? MaxInBatch { get; set; }
        string RequiresMashing { get; set; }
        List<Characteristic> Characteristics { get; set; }
        ISrm Srm { get; set; }
        ICountry Country { get; set; }
        double? CoarseFineDifference { get; set; }
        int? DiastaticPower { get; set; }
    }
}
