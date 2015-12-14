using BreweryDB.Resources;

namespace BreweryDB
{
    public class BreweryDbClient
    {
        public static string ApplicationKey { get; private set; }
        public static readonly string BaseAddress = "https://api.brewerydb.com/v2/";
        
        public BreweryDbClient(string key)
        {
            ApplicationKey = key;

            Beers = new BeerResource(this);
            Breweries = new BreweryResource(this);
            Categories = new CategoryResource(this);
            Adjuncts = new AdjunctResource(this);
            Yeasts = new YeastResource(this);
            SocialSites = new SocialSiteResource(this);
            Events = new EventResource(this);
            Features = new FeatureResource(this);
        }

        public AdjunctResource Adjuncts { get; private set; }
        public BeerResource Beers { get; private set; }
        public BreweryResource Breweries { get; private set; }
        public CategoryResource Categories { get; private set; }
        public YeastResource Yeasts { get; private set; }
        public SocialSiteResource SocialSites { get; set; }
        public EventResource Events { get; set; }
        public FeatureResource Features { get; set; }
    }
}