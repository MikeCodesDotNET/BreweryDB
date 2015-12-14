using System.Collections.Generic;
using System.Threading.Tasks;
using BreweryDB.Helpers;
using BreweryDB.Models;

namespace BreweryDB.Resources
{
    public class YeastResource
    {
        private readonly BreweryDbClient client;

        public YeastResource(BreweryDbClient breweryDbClient)
        {
            client = breweryDbClient;
        }

        async public Task<ResponseContainer<List<Yeast>>> GetAll()
        {
            return await GetAll(1);
        }

        async public Task<ResponseContainer<List<Yeast>>> GetAll(int pageNumber)
        {
            var url = $"{BreweryDbClient.BaseAddress}yeasts?p={pageNumber}&key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<Yeast>>>(url);
        }

        async public Task<ResponseContainer<Yeast>> Get(string id)
        {
            var url = $"{BreweryDbClient.BaseAddress}yeast/{id}?key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<Yeast>>(url);
        }
    }
}

