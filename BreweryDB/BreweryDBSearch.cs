using System;
using BreweryDB.Enums;
using BreweryDB.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Reactive.Linq;
using System.Text;

namespace BreweryDB
{
    public class BreweryDBSearch<T>
    {
        HttpClient httpClient;

        string searchTerm;
        SearchType type;
        bool withBreweries;

        //Premium features
        bool withSocialAccounts;
        bool withGuilds;
        bool withLocations;
        bool withAlternateNames;
        bool withIngredients;

        public BreweryDBSearch(string searchTerm)
        {
            this.searchTerm = searchTerm;
            withBreweries = true;
        }

        public BreweryDBSearch(string searchTerm, bool withBreweries)
        {
            this.searchTerm = searchTerm;
            this.type = type;
            this.withBreweries = withBreweries;
        }

        public async Task<IEnumerable<T>> Search()
        {
            if (httpClient == null)
                httpClient = new HttpClient();
            
            Response model;

            var parameters = new List<KeyValuePair<string, string>>();

            if (typeof(T) == typeof(Beer))
                type = SearchType.Beer;
            else if (typeof(T) == typeof(Brewery))
                type = SearchType.Brewery;
   
            parameters.Add(new KeyValuePair<string, string>("type", type.ToString().ToLower()));


            if (withBreweries)
                parameters.Add(new KeyValuePair<string, string>("withBreweries", "y"));

            if (withSocialAccounts)
                parameters.Add(new KeyValuePair<string, string>("withSocialAccounts", "y"));

            if (withGuilds)
                parameters.Add(new KeyValuePair<string, string>("withGuilds", "y"));

            if (withLocations)
                parameters.Add(new KeyValuePair<string, string>("withLocations", "y"));

            if (withAlternateNames)
                parameters.Add(new KeyValuePair<string, string>("withAlternateNames", "y"));

            if (withIngredients)
                parameters.Add(new KeyValuePair<string, string>("withIngredients", "y"));

            var url = string.Format("https://api.brewerydb.com/v2/search/?q={0}{1}", searchTerm, Helpers.ExtensionMethods.BuildParametersList(parameters));

            try
            {
                var response = await httpClient.GetAsync(url);
                var jsonString = await response.Content.ReadAsStringAsync();

                model = JsonConvert.DeserializeObject<Models.Response>(jsonString);
                model.Data = JsonConvert.DeserializeObject<IEnumerable<T>>(model.Data.ToString());

                var beersToReturn = model.Data as IEnumerable<T>;
                return beersToReturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public bool IncludeSocialAccounts
        {
            get
            {
                return withSocialAccounts;
            }
            set
            {
                withSocialAccounts = value;
            }
        }

        public bool IncludeGuilds
        {
            get
            {
                return withGuilds;
            }
            set
            {
                withGuilds = value;
            }
        }

        public bool IncludeLocations
        {
            get
            {
                return withLocations;
            }
            set
            {
                withLocations = value;
            }
        }

        public bool IncludeAlternateNames
        {
            get
            {
                return withAlternateNames;
            }
            set
            {
                withAlternateNames = value;
            }
        }

        public bool IncludeIngredients
        {
            get
            {
                return withIngredients;
            }
            set
            {
                withIngredients = value;
            }
        }
    }
}

