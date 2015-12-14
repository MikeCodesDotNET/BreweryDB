using System.Collections.Generic;
using System.Threading.Tasks;
using BreweryDB.Helpers;
using BreweryDB.Models;

namespace BreweryDB.Resources
{
    public class GuildResource
    {
        private readonly BreweryDbClient client;

        public GuildResource(BreweryDbClient breweryDbClient)
        {
            client = breweryDbClient;
        }

        async public Task<ResponseContainer<List<Guild>>> GetAll()
        {
            return await GetAll(1);
        }

        async public Task<ResponseContainer<List<Guild>>> GetAll(int pageNumber)
        {
            var url = $"{BreweryDbClient.BaseAddress}guilds?p={pageNumber}&key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<Guild>>>(url);
        }

        async public Task<ResponseContainer<Guild>> Get(string id)
        {
            var url = $"{BreweryDbClient.BaseAddress}guild/{id}?key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<Guild>>(url);
        }

        async public Task<ResponseContainer<List<Guild>>> Search(string keyword)
        {
            var url = $"{BreweryDbClient.BaseAddress}search?q={keyword}&type=guild&withBreweries=y&withSocialAccounts=y&withGuilds=y&withLocations=y&withAlternateNames=y&withIngredients=y&key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<Guild>>>(url);
        }
    }
}

