using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BreweryDB.Helpers;
using BreweryDB.Models;

namespace BreweryDB.Resources
{
    public class BreweryResource
    {
        private readonly BreweryDbClient client;

        public BreweryResource(BreweryDbClient breweryDbClient)
        {
            client = breweryDbClient;
        }

        async public Task<ResponseContainer<List<Brewery>>> GetAll()
        {
            return await GetAll(1);
        }

        async public Task<ResponseContainer<List<Brewery>>> GetAll(int pageNumber)
        {
            var url = $"{BreweryDbClient.BaseAddress}breweries?p={pageNumber}&key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<Brewery>>>(url);
        }

        async public Task<ResponseContainer<Brewery>> Get(string id)
        {
            var url = $"{BreweryDbClient.BaseAddress}brewery/{id}?key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<Brewery>>(url);
        }

        async public Task<ResponseContainer<List<Brewery>>> Get(NameValueCollection nvc)
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
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<Brewery>>>(url);
        }
    }
}
