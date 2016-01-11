using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryDB.Helpers;
using BreweryDB.Models;
using BreweryDB.Models.RequestParameters;
using BreweryDB.Resources;
using BreweryDB.Tests.Models;
using NUnit.Framework;

namespace BreweryDB.Tests
{
    [TestFixture()]
    public class Beers
    {
        private readonly BreweryDbClient client = new BreweryDbClient(Keys.ApplicationKey);

        [Test()]
        public async Task GetAll()
        {
            var response = await client.Beers.GetAll();

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 1);

            var beer = response.Data.FirstOrDefault();

            //Images
            Assert.IsTrue(beer.Labels != null);
            Assert.IsNotEmpty(beer.Labels.Large);

            //Breweries
            Assert.IsTrue(beer.Breweries != null);
        
        }

        [Test()]
        public async Task GetPage()
        {
            var response = await client.Beers.GetAll(4);

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 4);

            var beer = response.Data.FirstOrDefault();
            Assert.IsNotNull(beer);
        }

        [Test()]
        public async Task GetWithParameters()
        {
            var parameters = new NameValueCollection {{BeerRequestParameters.Name, "duvel single"}};
            var response = await client.Beers.Get(parameters);

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 1);
            Assert.IsTrue(response.NumberOfPages >= 1);
            Assert.IsTrue(response.TotalResults >= 1);

            var beer = response.Data.FirstOrDefault();
            Assert.IsNotNull(beer);
        }

        [Test()]
        public async Task Search()
        {
            var response = await client.Beers.Search("duvel");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 1);
            Assert.IsTrue(response.NumberOfPages >= 1);
            Assert.IsTrue(response.TotalResults >= 6);

            var beer = response.Data.FirstOrDefault();
            Assert.IsNotNull(beer);
        }

        [Test()]
        public async Task CustomType()
        {
            var newClient = new BreweryDbClient(Keys.ApplicationKey);
            var Beers = new BeerResource<MyBeer>(newClient);
            
            var response = await Beers.GetAll();
            
            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 1);
            Assert.IsTrue(response.NumberOfPages >= 1);
            Assert.IsTrue(response.TotalResults >= 1019);

        }

        [Test()]
        public async Task HasImages()
        {
            var response = await client.Beers.Search("Stella");

            Assert.IsTrue(response.Status == "success");

            var beer = response.Data.FirstOrDefault(x => x.Id == "Jc7iGI");
            Assert.IsNotNull(beer.Labels);
        }
    }
}
