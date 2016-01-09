using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BreweryDB.Helpers;
using BreweryDB.Models;

namespace BreweryDB.Resources
{
    public class BreweryResource<T>
    {
        private readonly BreweryDbClient client;

        public BreweryResource(BreweryDbClient breweryDbClient)
        {
            client = breweryDbClient;
        }

        public async Task<ResponseContainer<List<T>>> GetAll()
        {
            return await GetAll(1);
        }

        public async Task<ResponseContainer<List<T>>> GetAll(int pageNumber)
        {
            var url = $"{BreweryDbClient.BaseAddress}breweries?p={pageNumber}&key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<T>>>(url);
        }

        public async Task<ResponseContainer<T>> Get(string id)
        {
            var url = $"{BreweryDbClient.BaseAddress}brewery/{id}?key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<T>>(url);
        }

        public async Task<ResponseContainer<List<T>>> Get(NameValueCollection nvc)
        {
            var parameterBuilder = new StringBuilder();
            foreach (var parameter in nvc)
            {
                parameterBuilder.Append(parameter.Key);
                parameterBuilder.Append("=");
                parameterBuilder.Append(parameter.Value);
                parameterBuilder.Append("&");
            }

            var url = $"{BreweryDbClient.BaseAddress}breweries?{parameterBuilder}key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<T>>>(url);
        }

        public async Task<ResponseContainer<List<T>>> Search(string keyword)
        {
            var url = $"{BreweryDbClient.BaseAddress}search?q={keyword}&type=brewery&withSocialAccounts=y&withGuilds=y&withLocations=y&withAlternateNames=y&withIngredients=y&key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<T>>>(url);
        }
    }
}
