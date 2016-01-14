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
    public class Adjuncts
    {
        private readonly BreweryDbClient client = new BreweryDbClient(Keys.ApplicationKey);

        [Test()]
        public async Task ById()
        {
            var response = await client.Adjuncts.Get("923");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.Message == "Request Successful");

            var adjunct = response.Data;
            Assert.IsTrue(adjunct.Id == "923");
            Assert.IsTrue(adjunct.Name == "Banana");
            Assert.IsTrue(adjunct.Category == "misc");
            Assert.IsTrue(adjunct.CategoryDisplay == "Miscellaneous");

        }

        [Test()]
        public async Task GetAll()
        {
            var response = await client.Adjuncts.GetAll();

            Assert.IsTrue(response.Status == "success");

            var adjunct = response.Data.FirstOrDefault();
            Assert.IsTrue(adjunct.Id == "876");
            Assert.IsTrue(adjunct.Name == "Acid Blend");
            Assert.IsTrue(adjunct.Category == "misc");
            Assert.IsTrue(adjunct.CategoryDisplay == "Miscellaneous");
        }

        [Test()]
        public async Task GetPage()
        {
            var response = await client.Adjuncts.GetAll(4);

            Assert.IsTrue(response.Status == "success");

            var adjunct = response.Data.FirstOrDefault();
            Assert.IsTrue(adjunct.Id == "1014");
            Assert.IsTrue(adjunct.Name == "Cherry Puree");
            Assert.IsTrue(adjunct.Category == "misc");
            Assert.IsTrue(adjunct.CategoryDisplay == "Miscellaneous");
        }
    }
}
