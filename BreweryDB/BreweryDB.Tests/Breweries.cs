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
    public class Breweries
    {
        private readonly BreweryDbClient client = new BreweryDbClient(Keys.ApplicationKey);

        [Test()]
        public async Task ById()
        {
            var response = await client.Breweries.Get("YXDiJk");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.Message == "Request Successful");

            var brewery = response.Data;
            Assert.IsTrue(brewery.Id == "YXDiJk");
            Assert.IsTrue(brewery.Name == "#FREEDOM Craft Brewery");
        }

        [Test()]
        public async Task GetAll()
        {
            var response = await client.Breweries.GetAll();

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 1);
            Assert.IsTrue(response.NumberOfPages >= 141);
            Assert.IsTrue(response.TotalResults >= 7044);

            var brewery = response.Data.FirstOrDefault();
            Assert.IsTrue(brewery.Id == "YXDiJk");
            Assert.IsTrue(brewery.Name == "#FREEDOM Craft Brewery");
        }

        [Test()]
        public async Task GetPage()
        {
            var response = await client.Breweries.GetAll(4);

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 4);
            Assert.IsTrue(response.NumberOfPages >= 100);
            Assert.IsTrue(response.TotalResults >= 6000);

            var beer = response.Data.FirstOrDefault();
            Assert.IsNotNull(beer);

        }

        [Test()]
        public async Task GetWithParameters()
        {
            var parameters = new Helpers.NameValueCollection {{BreweryRequestParameters.Name, "Ad Lib Brewing Company" } };
            var response = await client.Breweries.Get(parameters);

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 1);
            Assert.IsTrue(response.NumberOfPages >= 1);
            Assert.IsTrue(response.TotalResults >= 1);

            var beer = response.Data.FirstOrDefault();
            Assert.IsTrue(beer?.Id == "aJQnv0");
            Assert.IsTrue(beer.Name == "Ad Lib Brewing Company");
        }

        [Test()]
        public async Task Search()
        {
            var response = await client.Breweries.Search("duvel");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 1);
            Assert.IsTrue(response.NumberOfPages >= 1);
            Assert.IsTrue(response.TotalResults >= 1);

            var brewery = response.Data.FirstOrDefault();
            Assert.IsNotNull(brewery);
        }
    }
}
