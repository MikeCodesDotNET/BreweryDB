using System;
using System.Collections.Generic;
using BreweryDB.Interfaces;
using BreweryDB.Models;

namespace BreweryDB.Tests.Models
{
    public class MyBeer  : IBeer
    {
        public MyBeer(Glass glass, Srm srm, Available available, Style style, List<Brewery> breweries, Labels labels,
            List<SocialAccount> socialAccounts)
        {
            Glass = glass;
            Srm = srm;
            Available = available;
            Style = style;
            Breweries = breweries;
            Labels = labels;
        } 

        public string Id { get; set; }
        public string Name { get; set; }
        public string NameDisplay { get; set; }
        public string Description { get; set; }
        public double Abv { get; set; }
        public int GlasswareId { get; set; }
        public int SrmId { get; set; }
        public int AvailableId { get; set; }
        public int StyleId { get; set; }
        public string IsOrganic { get; set; }
        public string Status { get; set; }
        public string StatusDisplay { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public IGlass Glass { get; set; }
        public ISrm Srm { get; set; }
        public IAvailable Available { get; set; }
        public IStyle Style { get; set; }
        public List<Brewery> Breweries { get; set; }
        public ILabels Labels { get; set; }
        public List<ISocialAccount> SocialAccounts  { get; set; }
        public string ServingTemperature { get; set; }

        public string Brewery => Breweries != null ? Breweries[0].Name : string.Empty;
         
        
    }
}