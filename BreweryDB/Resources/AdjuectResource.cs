using System.Collections.Generic;
using System.Threading.Tasks;
using BreweryDB.Helpers;
using BreweryDB.Models;

namespace BreweryDB.Resources
{
    public class AdjunctResource
    {
        private readonly BreweryDbClient client;

        public AdjunctResource(BreweryDbClient breweryDbClient)
        {
            client = breweryDbClient;
        }

        async public Task<ResponseContainer<List<Adjunct>>> GetAll()
        {
            return await GetAll(1);
        }

        async public Task<ResponseContainer<List<Adjunct>>> GetAll(int pageNumber)
        {
            var url = $"{BreweryDbClient.BaseAddress}adjuncts?p={pageNumber}&key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<Adjunct>>>(url);
        }

        async public Task<ResponseContainer<Adjunct>> Get(string id)
        {
            var url = $"{BreweryDbClient.BaseAddress}adjunct/{id}?key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<Adjunct>>(url);
        }
    }
}

