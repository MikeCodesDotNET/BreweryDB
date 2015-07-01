using NUnit.Framework;
using BreweryDB.Models;
using System.Collections.Generic;

namespace BreweryDB.Tests
{
    [TestFixture()]
    public class Search
    {
        [Test()]
        public async void ForBeersByName()
        {
            BreweryDBClient.Initialize(Keys.ApplicationKey, "BeerDrinkin");

            var query = new BreweryDBSearch<Beer>("duvel");
            var results = await query.Search();

            Assert.IsNotNull(results);
        }

        [Test()]
        public async void IncludeSocial()
        {
            BreweryDBClient.Initialize(Keys.ApplicationKey, "BeerDrinkin");

            var query = new BreweryDBSearch<Beer>("duvel")
            {
                IncludeSocialAccounts = true
            };
            var results = await query.Search();

            Assert.IsNotNull(results);
        }


        [Test()]
        public async void ForBreweryByBeerName()
        {
            BreweryDBClient.Initialize(Keys.ApplicationKey, "BeerDrinkin");

            var query = new BreweryDBSearch<Brewery>("duvel");
            var results = await query.Search();

            Assert.IsNotNull(results);
        }
       

    }
}

