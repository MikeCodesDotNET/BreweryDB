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
        public async void ById()
        {
            var response = await client.Breweries.Get("YXDiJk");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.Message == "Request Successful");

            var brewery = response.Data;
            Assert.IsTrue(brewery.Id == "YXDiJk");
            Assert.IsTrue(brewery.Name == "#FREEDOM Craft Brewery");
        }

        [Test()]
        public async void GetAll()
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
        public async void GetPage()
        {
            var response = await client.Breweries.GetAll(4);

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 4);
            Assert.IsTrue(response.NumberOfPages >= 141);
            Assert.IsTrue(response.TotalResults >= 7044);

            var beer = response.Data.FirstOrDefault();
            Assert.IsTrue(beer.Id == "aJQnv0");
        }

        [Test()]
        public async void GetWithParameters()
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
        public async void Search()
        {
            var response = await client.Breweries.Search("duvel");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 1);
            Assert.IsTrue(response.NumberOfPages >= 1);
            Assert.IsTrue(response.TotalResults >= 2);

            var brewery = response.Data.FirstOrDefault();
            Assert.IsNotNull(brewery);
        }
    }
}
