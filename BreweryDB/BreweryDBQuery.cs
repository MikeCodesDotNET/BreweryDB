using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using BreweryDB.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Collections.ObjectModel;
using BreweryDB.Helpers;
using System.Reactive.Linq;

namespace BreweryDB
{
    public class BreweryDBQuery<T>
    {
        HttpClient httpClient;

        public BreweryDBQuery()
        {
            Initialize();
        }

        void Initialize()
        {
            httpClient = httpClient ?? new HttpClient();

            if (BreweryDBClient.ApplicationKey == string.Empty)
                throw new Exception("No Application Key set. You must intialize BreweryDBClient before use");
        }

        #region Find

        /// <summary>
        /// Returns all the objects in the database which are of this type.
        /// </summary>
        /// <returns>The async.</returns>
        public async Task<Page<T>> FindAsync()
        {
            return await Find(new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// This will normally find just 1 item in the DB that matches the search term. Its unique to the type as well. 
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="name">Name.</param>
        public async Task<Page<T>> FindAsync(string name)
        {
            var nameParameter = new KeyValuePair<string, string>("name", name);
            var paramList = new List<KeyValuePair<string, string>>();
            paramList.Add(nameParameter);

            return await Find(paramList);
        }

        public async Task<Page<T>> FindAsync(List<KeyValuePair<string, string>> parameters)
        {
            return await Find(parameters);
        }

        async Task<Page<T>> Find(List<KeyValuePair<string, string>> parameters)
        {
            string param = ExtensionMethods.BuildParametersList(parameters);

            var url = BuildUrl(param);
            var jsonString = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<Page<T>>(jsonString);
        }

        #endregion

        #region Search

        //Searching the DB will return lots of data. 9 times out of 10 you'll want to be searching for beers and breweries rather than findng them.
        public async Task<IEnumerable<T>> SearchAsync(string searchTerm)
        {
            Response model;

            var url = string.Format("https://api.brewerydb.com/v2/search/?q={0}&withBreweries=n&key={1}&format=json", searchTerm, BreweryDBClient.ApplicationKey);

            var task = httpClient.GetAsync(url);

            var response = task.Result;

            var jsonString = await httpClient.GetStringAsync(url);
            model = JsonConvert.DeserializeObject<Models.Response>(jsonString.ToString());
            model.Data = JsonConvert.DeserializeObject<ObservableCollection<T>>(model.Data.ToString());

            var beersToReturn = model.Data as ObservableCollection<T>;

            return beersToReturn;
        }

        #endregion

        #region Private

        string BuildUrl(string param)
        {
            var queryType = string.Empty;

            if (typeof(T) == typeof(Beer))
                queryType = "beers";

            if (typeof(T) == typeof(Brewery))
                queryType = "breweries";
            
            return string.Format("https://api.brewerydb.com/v2/{0}?{1}", queryType, param);
        }

        #endregion
    }
}

