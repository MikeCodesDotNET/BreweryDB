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
    public class Categories
    {
        private readonly BreweryDbClient client = new BreweryDbClient(Keys.ApplicationKey);

        [Test()]
        public async Task ById()
        {
            var response = await client.Categories.Get("1");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.Message == "Request Successful");

            var category = response.Data;
            Assert.IsTrue(category.Id == "1");
            Assert.IsTrue(category.Name == "British Origin Ales");
        }

        [Test()]
        public async Task GetAll()
        {
            var response = await client.Categories.GetAll();

            Assert.IsTrue(response.Status == "success");

            var category = response.Data.FirstOrDefault();
            Assert.IsTrue(category.Id == "1");
            Assert.IsTrue(category.Name == "British Origin Ales");
        }
    }
}
