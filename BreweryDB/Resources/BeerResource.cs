using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BreweryDB.Helpers;
using BreweryDB.Models;

namespace BreweryDB.Resources
{
    public class BeerResource 
    {
        private BreweryDbClient client;

        public BeerResource(BreweryDbClient breweryDbClient)
        {
            client = breweryDbClient;
        }

        async public Task<ResponseContainer<List<Beer>>> GetAll()
        {
            return await GetAll(1);
        }

        async public Task<ResponseContainer<List<Beer>>> GetAll(int pageNumber)
        {
            var url = $"{BreweryDbClient.BaseAddress}beers?p={pageNumber}&key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<Beer>>>(url);            
        }

        async public Task<ResponseContainer<Beer>> Get(string id)
        {
            var url = $"{BreweryDbClient.BaseAddress}beer/{id}?key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<Beer>>(url);
        }

        async public Task<ResponseContainer<List<Beer>>> Get(NameValueCollection nvc)
        {
            var parameterBuilder = new StringBuilder();
            foreach (var parameter in nvc)
            {
                parameterBuilder.Append(parameter.Key);
                parameterBuilder.Append("=");
                parameterBuilder.Append(parameter.Value);
                parameterBuilder.Append("&");
            }

            var url = $"{BreweryDbClient.BaseAddress}beers?{parameterBuilder}key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<Beer>>>(url);
        }

        async public Task<ResponseContainer<List<Beer>>> Search(string keyword)
        {
            var url = $"{BreweryDbClient.BaseAddress}search?q={keyword}&type=beer&withBreweries=y&withSocialAccounts=y&withGuilds=y&withLocations=y&withAlternateNames=y&withIngredients=y&key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<Beer>>>(url);
        }
    }
}
