using System.Collections.Generic;
using System.Threading.Tasks;
using BreweryDB.Helpers;
using BreweryDB.Models;

namespace BreweryDB.Resources
{
    public class AdjunctResource<T>
    {
        private readonly BreweryDbClient client;

        public AdjunctResource(BreweryDbClient breweryDbClient)
        {
            client = breweryDbClient;
        }

        public async Task<ResponseContainer<List<T>>> GetAll()
        {
            return await GetAll(1);
        }

        public async Task<ResponseContainer<List<T>>> GetAll(int pageNumber)
        {
            var url = $"{BreweryDbClient.BaseAddress}adjuncts?p={pageNumber}&key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<T>>>(url);
        }

        public async Task<ResponseContainer<T>> Get(string id)
        {
            var url = $"{BreweryDbClient.BaseAddress}adjunct/{id}?key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<T>>(url);
        }
    }
}

