using System.Collections.Generic;
using System.Threading.Tasks;
using BreweryDB.Helpers;
using BreweryDB.Models;

namespace BreweryDB.Resources
{
    public class FluidSizeResource
    {
        private readonly BreweryDbClient client;

        public FluidSizeResource(BreweryDbClient breweryDbClient)
        {
            client = breweryDbClient;
        }

        async public Task<ResponseContainer<List<FluidSize>>> GetAll()
        {
            var url = $"{BreweryDbClient.BaseAddress}fluidsizes?key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<FluidSize>>>(url);
        }

        async public Task<ResponseContainer<FluidSize>> Get(string id)
        {
            var url = $"{BreweryDbClient.BaseAddress}fluidsize/{id}?key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<FluidSize>>(url);
        }
    }
}

