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
    public class Yeasts
    {
        private readonly BreweryDbClient client = new BreweryDbClient(Keys.ApplicationKey);

        [Test()]
        public async Task ById()
        {
            var response = await client.Yeasts.Get("1531");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.Message == "Request Successful");

            var yeast = response.Data;
            Assert.IsNotNull(yeast);

        }

        [Test()]
        public async Task GetAll()
        {
            var response = await client.Yeasts.GetAll();

            Assert.IsTrue(response.Status == "success");

            var yeast = response.Data.FirstOrDefault();
            Assert.IsNotNull(yeast);
        }

        [Test()]
        public async Task GetPage()
        {
            var response = await client.Yeasts.GetAll(4);

            Assert.IsTrue(response.Status == "success");

            var yeast = response.Data.FirstOrDefault();
            Assert.IsNotNull(yeast);
        }
    }
}
