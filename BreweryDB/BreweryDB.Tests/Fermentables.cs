using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryDB.Helpers;
using BreweryDB.Models;
using BreweryDB.Models.RequestParameters;
using NUnit.Framework;

namespace BreweryDB.Tests
{
    [TestFixture()]
    public class Fermentables
    {
        private readonly BreweryDbClient client = new BreweryDbClient(Keys.ApplicationKey);

        [Test()]
        public async void ById()
        {
            var response = await client.Fermentables.Get("165");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.Message == "Request Successful");

            var fermentable = response.Data;
            Assert.IsTrue(fermentable.Id == "165");
            Assert.IsTrue(fermentable.Name == "Abbey Malt");
            Assert.IsTrue(fermentable.Category == "malt");
            Assert.IsTrue(fermentable.CategoryDisplay == "Malts, Grains, & Fermentables");
        }

        [Test()]
        public async void GetAll()
        {
            var response = await client.Fermentables.GetAll();

            Assert.IsTrue(response.Status == "success");

            var fermentable = response.Data.FirstOrDefault();
            Assert.IsTrue(fermentable.Id == "165");
            Assert.IsTrue(fermentable.Name == "Abbey Malt");
            Assert.IsTrue(fermentable.Category == "malt");
            Assert.IsTrue(fermentable.CategoryDisplay == "Malts, Grains, & Fermentables");
        }

        [Test()]
        public async void GetPage()
        {
            var response = await client.Fermentables.GetAll(3);

            Assert.IsTrue(response.Status == "success");

            var fermentable = response.Data.FirstOrDefault();
            Assert.IsTrue(fermentable.Id == "427");
            Assert.IsTrue(fermentable.Name == "Cherry Smoked");
            Assert.IsTrue(fermentable.Category == "malt");
            Assert.IsTrue(fermentable.CategoryDisplay == "Malts, Grains, & Fermentables");
        }
    }
}
