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
        const string _apiKey = "";
        public BreweryDBClient(string key = _apiKey)
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

        public ObservableCollection<Models.Beer> SearchForBeer(string name)
        {
            try
            {
                if (_client == null)
                    _client = new HttpClient();

                Models.Response model;

                var url = string.Format("https://api.brewerydb.com/v2/search/?q={0}&key={1}&format=json", name, _key);
                var response = _client.GetAsync(url).Result;

                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                model = JsonConvert.DeserializeObject<Models.Response>(jsonString.Result);
                model.Data = JsonConvert.DeserializeObject<ObservableCollection<Models.Beer>>(model.Data.ToString());

                return model.Data as ObservableCollection<Models.Beer>;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        private HttpClient _client;
        private string _key;
    }
}
