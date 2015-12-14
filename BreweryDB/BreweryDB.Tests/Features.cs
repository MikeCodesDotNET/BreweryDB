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
    public class Features
    {
        private readonly BreweryDbClient client = new BreweryDbClient(Keys.ApplicationKey);

        [Test()]
        public async void ByDate()
        {
            var response = await client.Features.Get(new DateTime(2012, 04, 1));

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.Message == "Request Successful");

            var feature = response.Data;
            Assert.IsTrue(feature.Id == "2");
            Assert.IsTrue(feature.Year == 2012);
            Assert.IsTrue(feature.Week == 4);
            Assert.IsTrue(feature.BreweryId == "iG2UXJ");

        }

        [Test()]
        public async void GetAll()
        {
            var response = await client.Features.GetAll();

            var feature = response.Data.FirstOrDefault();
            Assert.IsTrue(feature.Id == "117");
            Assert.IsTrue(feature.Year == 2015);
            Assert.IsTrue(feature.Week == 5);
            Assert.IsTrue(feature.BreweryId == "DXvlfF");
        }

        [Test()]
        public async void ThisWeeks()
        {
            var response = await client.Features.ThisWeeks();

            var feature = response.Data;
            Assert.IsTrue(feature.Id == "117");
            Assert.IsTrue(feature.Year == 2015);
            Assert.IsTrue(feature.Week == 5);
            Assert.IsTrue(feature.BreweryId == "DXvlfF");
        }

    }
}
