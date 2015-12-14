using System.Collections.Generic;
using System.Threading.Tasks;
using BreweryDB.Helpers;
using BreweryDB.Models;

namespace BreweryDB.Resources
{
    public class FermentableResource
    {
        private readonly BreweryDbClient client;

        public FermentableResource(BreweryDbClient breweryDbClient)
        {
            client = breweryDbClient;
        }

        async public Task<ResponseContainer<List<Fermentable>>> GetAll()
        {
            return await GetAll(1);
        }

        async public Task<ResponseContainer<List<Fermentable>>> GetAll(int pageNumber)
        {
            var url = $"{BreweryDbClient.BaseAddress}fermentables?p={pageNumber}&key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<Fermentable>>>(url);
        }

        async public Task<ResponseContainer<Fermentable>> Get(string id)
        {
            var url = $"{BreweryDbClient.BaseAddress}fermentable/{id}?key={BreweryDbClient.ApplicationKey}&format=json";
           return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<Fermentable>>(url);
        }
    }
}

