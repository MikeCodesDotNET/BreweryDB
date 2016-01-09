using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryDB.Models;

namespace BreweryDB.Interfaces
{
    public interface IBeer 
    {
        string Id { get; set; }
        string Name { get; set; }
        string NameDisplay { get; set; }
        string Description { get; }
        double Abv { get; set; }
        int GlasswareId { get; set; }
        int SrmId { get; set; }
        int AvailableId { get; set; }
        int StyleId { get; set; }
        string IsOrganic { get; set; }
        string Status { get; set; }
        string StatusDisplay { get; set; }
        string CreateDate { get; set; }
        string UpdateDate { get; set; }
        IGlass Glass { get; set; }
        ISrm Srm { get; set; }
        IAvailable Available { get; set; }
        IStyle Style { get; set; }
        List<Brewery> Breweries { get; set; }
        ILabels Labels { get; set; }
        List<ISocialAccount> SocialAccounts { get; set; }
        string ServingTemperature { get; set; }
        string Brewery { get; }
    }
}
