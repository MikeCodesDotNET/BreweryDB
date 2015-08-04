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


        public BreweryDBClient(string key)
        {
            _key = key;
        }

        public Models.Beer QueryBeerById(string id)
        {
            if (_client == null)
                _client = new HttpClient();

            Models.Response model;

            var url = string.Format("https://api.brewerydb.com/v2/beer/{0}?key={1}&format=json", id, _key);
            var task = _client.GetAsync(url);

            var response = task.Result;
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

                var url = string.Format("https://api.brewerydb.com/v2/search/?q={0}&withBreweries=y&key={1}&format=json", name, _key);
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

        private HttpClient _client;
        private string _key;
    }
}
