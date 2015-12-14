using System.Collections.Generic;
using System.Threading.Tasks;
using BreweryDB.Helpers;
using BreweryDB.Models;

namespace BreweryDB.Resources
{
    public class SocialSiteResource
    {
        private readonly BreweryDbClient client;

        public SocialSiteResource(BreweryDbClient breweryDbClient)
        {
            client = breweryDbClient;
        }

        async public Task<ResponseContainer<List<SocialSite>>> GetAll()
        {
            var url = $"{BreweryDbClient.BaseAddress}socialsites?key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<SocialSite>>>(url);
        }

        async public Task<ResponseContainer<SocialSite>> Get(string id)
        {
            var url = $"{BreweryDbClient.BaseAddress}socialsite/{id}?key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<SocialSite>>(url);
        }
    }
}

