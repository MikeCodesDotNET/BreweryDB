using System.Collections.Generic;
using System.Threading.Tasks;
using BreweryDB.Helpers;
using BreweryDB.Models;

namespace BreweryDB.Resources
{
    public class CategoryResource
    {
        private readonly BreweryDbClient client;

        public CategoryResource(BreweryDbClient breweryDbClient)
        {
            client = breweryDbClient;
        }

        async public Task<ResponseContainer<List<Category>>> GetAll()
        {
            var url = $"{BreweryDbClient.BaseAddress}categories?&key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<Category>>>(url);
        }

        async public Task<ResponseContainer<Category>> Get(string id)
        {
            var url = $"{BreweryDbClient.BaseAddress}category/{id}?key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<Category>>(url);
        }
    }
}

