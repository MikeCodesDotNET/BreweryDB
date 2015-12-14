using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryDB.Helpers;
using BreweryDB.Models;

namespace BreweryDB.Resources
{
    public class EventResource
    {
        private readonly BreweryDbClient client;

        public EventResource(BreweryDbClient breweryDbClient)
        {
            client = breweryDbClient;
        }

        async public Task<ResponseContainer<List<Event>>> GetAll()
        {
            return await GetAll(1);
        }

        async public Task<ResponseContainer<List<Event>>> GetAll(int pageNumber)
        {
            var url = $"{BreweryDbClient.BaseAddress}events?p={pageNumber}&key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<Event>>>(url);
        }

        async public Task<ResponseContainer<Event>> Get(string id)
        {
            var url = $"{BreweryDbClient.BaseAddress}event/{id}?key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<Event>>(url);
        }

        async public Task<ResponseContainer<List<Event>>> Get(NameValueCollection nvc)
        {
            var parameterBuilder = new StringBuilder();
            foreach (var parameter in nvc)
            {
                parameterBuilder.Append(parameter.Key);
                parameterBuilder.Append("=");
                parameterBuilder.Append(parameter.Value);
                parameterBuilder.Append("&");
            }

            var url = $"{BreweryDbClient.BaseAddress}events?{parameterBuilder}key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<Event>>>(url);
        }

        async public Task<ResponseContainer<List<Event>>> Search(string keyword)
        {
            var url = $"{BreweryDbClient.BaseAddress}search?q={keyword}&type=event&withBreweries=y&withSocialAccounts=y&withGuilds=y&withLocations=y&withAlternateNames=y&withIngredients=y&key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<Event>>>(url);
        }

    }
}

