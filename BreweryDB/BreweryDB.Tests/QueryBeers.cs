using System;
using NUnit.Framework;
using BreweryDB.Models;
using System.Collections.Generic;
using System.Linq;
using BreweryDB.Enums;

namespace BreweryDB.Tests
{
    [TestFixture()]
    public class QueryBeers
    {
        [Test()]
        public async void AllBeers()
        {
            BreweryDBClient.Initialize(Keys.ApplicationKey, "BeerDrinkin");

            var query = new BreweryDBQuery<Beer>();
            var results = await query.FindAsync();

            Assert.IsNotNull(results);
        }
      
        [Test()]
        public async void ByName()
        {
            BreweryDBClient.Initialize(Keys.ApplicationKey, "BeerDrinkin");

            var query = new BreweryDBQuery<Beer>();
            var results = await query.FindAsync("duvel");

            Assert.IsTrue(results.Data[0].Name == "Duvel");
        }

        [Test()]
        public async void SearchByName()
        {
            BreweryDBClient.Initialize(Keys.ApplicationKey, "BeerDrinkin");

            var query = new BreweryDBQuery<Beer>();
            var results = await query.SearchAsync("duvel");

            Assert.IsNotNull(results);
        }

        [Test()]
        public async void ById()
        {
            BreweryDBClient.Initialize(Keys.ApplicationKey, "BeerDrinkin");
            var id = "c8VKLu"; //ID for Duvel

            var parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>(BeerRequestParameters.ids.ToString(), id));

            var query = new BreweryDBQuery<Beer>();
            var results = await query.FindAsync(parameters);

            Assert.IsTrue(results.Data[0].Id == id);
        }

        [Test()]
        public async void ByAbv()
        {
            BreweryDBClient.Initialize(Keys.ApplicationKey, "BeerDrinkin");

            var parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>(BeerRequestParameters.abv.ToString(), "8.5"));

            var query = new BreweryDBQuery<Beer>();
            var results = await query.FindAsync(parameters);

            Assert.IsTrue(results.Data[0].Abv == "8.5");
        }

    }
}

