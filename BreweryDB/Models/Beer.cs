using System;
using System.Collections.Generic;
using BreweryDB.Helpers;
using BreweryDB.Interfaces;
using Newtonsoft.Json;

namespace BreweryDB.Models
{
    public class Beer  : IBeer
    {
        public Beer(IGlass glass, ISrm srm, IAvailable available, IStyle style, List<Brewery> breweries, ILabels labels,
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
        public double IBU { get; set; }
        public int GlasswareId { get; set; }
        public int SrmId { get; set; }
        public int AvailableId { get; set; }
        public int StyleId { get; set; }
        public string IsOrganic { get; set; }
        public string Status { get; set; }
        public string StatusDisplay { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }

        [JsonConverter(typeof(ConcreteConverter<Glass>))]
        public IGlass Glass { get; set; }

        [JsonConverter(typeof(ConcreteConverter<Srm>))]
        public ISrm Srm { get; set; }

        [JsonConverter(typeof(ConcreteConverter<Available>))]
        public IAvailable Available { get; set; }

        [JsonConverter(typeof(ConcreteConverter<Style>))]
        public IStyle Style { get; set; }
        public List<Brewery> Breweries { get; set; }

        [JsonConverter(typeof(ConcreteConverter<Labels>))]
        public ILabels Labels { get; set; }
        public List<ISocialAccount> SocialAccounts  { get; set; }
        public string ServingTemperature { get; set; }

        public string Brewery => Breweries != null ? Breweries[0].Name : string.Empty;
         
        
    }
}