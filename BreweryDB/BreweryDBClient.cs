using BreweryDB.Interfaces;
using BreweryDB.Models;
using BreweryDB.Resources;
using System.Net.Http;
using System;
using BreweryDB.Helpers;

namespace BreweryDB
{
    public class BreweryDbClient
    {
        public static string ApplicationKey { get; private set; }
        public static readonly string BaseAddress = "https://api.brewerydb.com/v2/";
        
        public BreweryDbClient(string key, Func<HttpClient> httpClientFactory = null)
        {
            ApplicationKey = key;

            if (httpClientFactory != null)
                JsonDownloader.HttpClientFactory = httpClientFactory;

            Beers = new BeerResource<Beer>(this);
            Breweries = new BreweryResource<Brewery>(this);
            Categories = new CategoryResource<Category>(this);
            Adjuncts = new AdjunctResource<Adjunct>(this);
            Yeasts = new YeastResource<Yeast>(this);
            SocialSites = new SocialSiteResource<SocialSite>(this);
            Events = new EventResource<Event>(this);
            Features = new FeatureResource<Feature>(this);
            Guildes = new GuildResource<Guild>(this);
            Fermentables = new FermentableResource<Fermentable>(this);
            FluidSizes = new FluidSizeResource<FluidSize>(this);
            Changes = new ChangeResource<Change>(this);
        }

        public AdjunctResource<Adjunct> Adjuncts { get; set; }
        public BeerResource<Beer> Beers { get; set; }
        public BreweryResource<Brewery> Breweries { get; set; }
        public CategoryResource<Category> Categories { get; set; }
        public YeastResource<Yeast> Yeasts { get; set; }
        public SocialSiteResource<SocialSite> SocialSites { get; set; }
        public EventResource<Event> Events { get; set; }
        public FeatureResource<Feature> Features { get; set; }
        public GuildResource<Guild> Guildes { get; set; }
        public FermentableResource<Fermentable> Fermentables { get; set; }
        public FluidSizeResource<FluidSize> FluidSizes { get; set; }
        public ChangeResource<Change> Changes { get; set; }
    }
}