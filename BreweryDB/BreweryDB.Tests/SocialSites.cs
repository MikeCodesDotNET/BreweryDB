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
    public class SocialSites
    {
        private readonly BreweryDbClient client = new BreweryDbClient(Keys.ApplicationKey);

        [Test()]
        public async void ById()
        {
            var response = await client.SocialSites.Get("2");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.Message == "Request Successful");

            var socialSite = response.Data;
            Assert.IsTrue(socialSite.Id == "2");
            Assert.IsTrue(socialSite.Name == "Twitter");
            Assert.IsTrue(socialSite.Website == "http://www.twitter.com" == true);

        }

        [Test()]
        public async void GetAll()
        {
            var response = await client.SocialSites.GetAll();

            Assert.IsTrue(response.Status == "success");

            var socialSite = response.Data.FirstOrDefault(x => x.Id == "2");
            Assert.IsTrue(socialSite.Id == "2");
            Assert.IsTrue(socialSite.Name == "Twitter");
            Assert.IsTrue(socialSite.Website == "http://www.twitter.com" == true);
        }
        
    }
}
