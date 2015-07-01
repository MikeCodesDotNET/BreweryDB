using System;
using NUnit.Framework;
using BreweryDB.Models;
using System.Collections.Generic;
using System.Linq;
using BreweryDB.Enums;

namespace BreweryDB.Tests
{
    [TestFixture()]
    public class QueryBreweries
    {
        [Test()]
        public async void AllBreweries()
        {
            BreweryDBClient.Initialize(Keys.ApplicationKey, "BeerDrinkin");

            var query = new BreweryDBQuery<Brewery>();
            var results = await query.FindAsync();

            Assert.IsNotNull(results);
        }

        [Test()]
        public async void ByName()
        {
            BreweryDBClient.Initialize(Keys.ApplicationKey, "BeerDrinkin");
            var query = new BreweryDBQuery<Brewery>();
            var results = await query.FindAsync("Duvel Moortgat");

            Assert.IsTrue(results.Data[0].Name == "Duvel Moortgat");
        }

    }
}

