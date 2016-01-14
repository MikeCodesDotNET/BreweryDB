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
    public class Guilds
    {
        private readonly BreweryDbClient client = new BreweryDbClient(Keys.ApplicationKey);

        [Test()]
        public async Task ById()
        {
            var response = await client.Guildes.Get("EdRcIs");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.Message == "Request Successful");

            var guild = response.Data;
            Assert.IsTrue(guild.Id == "EdRcIs");
            Assert.IsTrue(guild.Name == "Alabama Brewers Guild");

        }

        [Test()]
        public async Task GetAll()
        {
            var response = await client.Guildes.GetAll();

            Assert.IsTrue(response.Status == "success");

            var guild = response.Data.FirstOrDefault();
            Assert.IsTrue(guild.Id == "EdRcIs");
            Assert.IsTrue(guild.Name == "Alabama Brewers Guild");
        }

        [Test()]
        public async Task GetPage()
        {
            var response = await client.Guildes.GetAll(2);

            Assert.IsTrue(response.Status == "success");

            var guild = response.Data.FirstOrDefault();
            Assert.IsNotNull(guild);
        }

        [Test()]
        public async Task Search()
        {
            var response = await client.Guildes.Search("Alabama Brewers Guild");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 1);
            Assert.IsTrue(response.NumberOfPages >= 1);
            Assert.IsTrue(response.TotalResults >= 59);

            var guild = response.Data.FirstOrDefault();
            Assert.IsTrue(guild?.Id == "EdRcIs");
            Assert.IsTrue(guild.Name == "Alabama Brewers Guild");
        }
    }
}
