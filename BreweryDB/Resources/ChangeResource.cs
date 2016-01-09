using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryDB.Helpers;
using BreweryDB.Models;

namespace BreweryDB.Resources
{
    public class ChangeResource<T>
    {
        private BreweryDbClient client;

        public ChangeResource(BreweryDbClient breweryDbClient)
        {
            client = breweryDbClient;
        }

        public async Task<ResponseContainer<List<T>>> GetAll()
        {
            return await GetAll(1);
        }

        public async Task<ResponseContainer<List<T>>> GetAll(int pageNumber)
        {
            var url = $"{BreweryDbClient.BaseAddress}changes?p={pageNumber}&key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<T>>>(url);
        }
    }
}
