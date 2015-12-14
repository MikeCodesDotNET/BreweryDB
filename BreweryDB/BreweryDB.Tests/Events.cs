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
    public class Events
    {
        private readonly BreweryDbClient client = new BreweryDbClient(Keys.ApplicationKey);

        [Test()]
        public async void ById()
        {
            var response = await client.Events.Get("cJio9R");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.Message == "Request Successful");

            var _event = response.Data;
            Assert.IsTrue(_event.Id == "cJio9R");
            Assert.IsTrue(_event.Year == "2008");
            Assert.IsTrue(_event.Name == "2008 Hickory Hops / Carolina Championship of ");
            Assert.IsTrue(_event.Type == "festival_competition");
        }

        [Test()]
        public async void GetAll()
        {
            var response = await client.Events.GetAll();

            Assert.IsTrue(response.Status == "success");

            var _event = response.Data.FirstOrDefault();
            Assert.IsTrue(_event.Id == "cJio9R");
            Assert.IsTrue(_event.Year == "2008");
            Assert.IsTrue(_event.Name == "2008 Hickory Hops / Carolina Championship of ");
            Assert.IsTrue(_event.Type == "festival_competition");
        }

        [Test()]
        public async void GetPage()
        {
            var response = await client.Events.GetAll(1);

            Assert.IsTrue(response.Status == "success");

            var _event = response.Data.FirstOrDefault();
            Assert.IsTrue(_event.Id == "cJio9R");
            Assert.IsTrue(_event.Year == "2008");
            Assert.IsTrue(_event.Name == "2008 Hickory Hops / Carolina Championship of ");
            Assert.IsTrue(_event.Type == "festival_competition");
        }

        [Test()]
        public async void GetWithParameters()
        {
            var parameters = new NameValueCollection { { EventRequestParameters.Year, "2008" } };
            var response = await client.Events.Get(parameters);

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 1);
            Assert.IsTrue(response.NumberOfPages >= 1);
            Assert.IsTrue(response.TotalResults >= 1);

            var _event = response.Data.FirstOrDefault();
            Assert.IsTrue(_event.Id == "cJio9R");
            Assert.IsTrue(_event.Year == "2008");
        }

        [Test()]
        public async void Search()
        {
            var response = await client.Events.Search("B'dam BrewJAM");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 1);
            Assert.IsTrue(response.NumberOfPages >= 1);
            Assert.IsTrue(response.TotalResults >= 1);

            var _event = response.Data.FirstOrDefault();
            Assert.IsTrue(_event?.Id == "28OVyf");
            Assert.IsTrue(_event.Name == "B'dam BrewJAM");
        }

    }
}
