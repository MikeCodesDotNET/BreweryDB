using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BreweryDB
{
    public class BreweryDBClient
    {
        public static string ApplicationKey;

        public static void Initialize(string apiKey)
        {
            ApplicationKey = apiKey;
        }

        public BreweryDBClient()
        {
        }

        public async Task<Models.Beer> QueryBeerById(string id)
        {
            if (_client == null)
                _client = new HttpClient();

            Models.Response model;

            var url = string.Format("https://api.brewerydb.com/v2/beer/{0}?key={1}&format=json", id, ApplicationKey);
            var task = await _client.GetAsync(url);

            var response = task;
            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();
            model = JsonConvert.DeserializeObject<Models.Response>(jsonString.Result);
            model.Data = JsonConvert.DeserializeObject<Models.Beer>(model.Data.ToString());

            return model.Data as Models.Beer;
        }

        public async Task<List<Models.Beer>> SearchForBeer(string name)
        {
            try
            {
                if (_client == null)
                    _client = new HttpClient();

                Models.Response model;

                var url = string.Format("https://api.brewerydb.com/v2/search/?q={0}&withBreweries=y&key={1}&format=json", name, ApplicationKey);
                var response = await _client.GetAsync(url);

                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                model = JsonConvert.DeserializeObject<Models.Response>(jsonString.Result);
                model.Data = JsonConvert.DeserializeObject<List<Models.Beer>>(model.Data.ToString());

                return model.Data as List<Models.Beer>;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Models.Brewery>> SearchForBrewery(string name)
        {
            try
            {
                if (_client == null)
                    _client = new HttpClient();

                Models.Response model;

                var url = string.Format("https://api.brewerydb.com/v2/breweries/?q={0}&key={1}&format=json", name, ApplicationKey);
                var response = await _client.GetAsync(url);

                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                model = JsonConvert.DeserializeObject<Models.Response>(jsonString.Result);
                model.Data = JsonConvert.DeserializeObject<List<Models.Beer>>(model.Data.ToString());

                return model.Data as List<Models.Brewery>;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        private HttpClient _client;
    }
}
