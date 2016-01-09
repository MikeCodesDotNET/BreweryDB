using System.Collections.Generic;
using System.Threading.Tasks;
using BreweryDB.Helpers;
using BreweryDB.Models;

namespace BreweryDB.Resources
{
    public class GuildResource<T>
    {
        private readonly BreweryDbClient client;

        public GuildResource(BreweryDbClient breweryDbClient)
        {
            client = breweryDbClient;
        }

        public async Task<ResponseContainer<List<T>>> GetAll()
        {
            return await GetAll(1);
        }

        public async Task<ResponseContainer<List<T>>> GetAll(int pageNumber)
        {
            var url = $"{BreweryDbClient.BaseAddress}guilds?p={pageNumber}&key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<T>>>(url);
        }

        public async Task<ResponseContainer<T>> Get(string id)
        {
            var url = $"{BreweryDbClient.BaseAddress}guild/{id}?key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<T>>(url);
        }

        public async Task<ResponseContainer<List<T>>> Search(string keyword)
        {
            var url = $"{BreweryDbClient.BaseAddress}search?q={keyword}&type=guild&withBreweries=y&withSocialAccounts=y&withGuilds=y&withLocations=y&withAlternateNames=y&withIngredients=y&key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<T>>>(url);
        }
    }
}

