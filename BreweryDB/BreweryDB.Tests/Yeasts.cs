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
        public async void ById()
        {
            var response = await client.Yeasts.Get("1531");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.Message == "Request Successful");

            var yeast = response.Data;
            Assert.IsTrue(yeast.Id == "1531");
            Assert.IsTrue(yeast.Name == "10th Anniversary Blend");
            Assert.IsTrue(yeast.Category == "yeast");
            Assert.IsTrue(yeast.CategoryDisplay == "Yeast");

        }

        [Test()]
        public async void GetAll()
        {
            var response = await client.Yeasts.GetAll();

            Assert.IsTrue(response.Status == "success");

            var yeast = response.Data.FirstOrDefault();
            Assert.IsTrue(yeast.Id == "1531");
            Assert.IsTrue(yeast.Name == "10th Anniversary Blend");
            Assert.IsTrue(yeast.Category == "yeast");
            Assert.IsTrue(yeast.CategoryDisplay == "Yeast");
        }

        [Test()]
        public async void GetPage()
        {
            var response = await client.Yeasts.GetAll(4);

            Assert.IsTrue(response.Status == "success");

            var yeast = response.Data.FirstOrDefault();
            Assert.IsTrue(yeast.Id == "1799");
            Assert.IsTrue(yeast.Name == "German Bock Lager");
            Assert.IsTrue(yeast.Category == "yeast");
            Assert.IsTrue(yeast.CategoryDisplay == "Yeast");
        }
    }
}
