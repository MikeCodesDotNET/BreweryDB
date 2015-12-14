using System;
using System.Net.Http;
using System.Threading.Tasks;
using BreweryDB.Models;
using BreweryDB.Resources;
using Newtonsoft.Json;
using System.Net;

namespace BreweryDB
{
    public class BreweryDbClient
    {
        public static string ApplicationKey { get; private set; }
        public static readonly string BaseAddress = "https://api.brewerydb.com/v2/";
        private readonly HttpClient client;
        
        public BreweryDbClient(string key)
        {
            ApplicationKey = key;
            client = new HttpClient();

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

        internal async Task<string> FetchJson(string url)
        {
            var response = await client.GetAsync(url);
            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var error = JsonConvert.DeserializeObject<Error>(jsonString.Result, new JsonSerializerSettings());
                throw error == null
                    ? new UnauthorizedAccessException(
                        $"Failed to authorize with BreweryDB. This is most likely due to an invalud URL. {url}")
                    : new UnauthorizedAccessException(
                        $"Error to authorize with BreweryDB. Returned error message : {error.Message}\r\n URL: {url} ");
            }

            return jsonString.Result;
        }
    }
}