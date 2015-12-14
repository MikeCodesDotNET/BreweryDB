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
        public async void ById()
        {
            var response = await client.Guildes.Get("EdRcIs");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.Message == "Request Successful");

            var guild = response.Data;
            Assert.IsTrue(guild.Id == "EdRcIs");
            Assert.IsTrue(guild.Name == "Alabama Brewers Guild");

        }

        [Test()]
        public async void GetAll()
        {
            var response = await client.Guildes.GetAll();

            Assert.IsTrue(response.Status == "success");

            var guild = response.Data.FirstOrDefault();
            Assert.IsTrue(guild.Id == "EdRcIs");
            Assert.IsTrue(guild.Name == "Alabama Brewers Guild");
        }

        [Test()]
        public async void GetPage()
        {
            var response = await client.Guildes.GetAll(2);

            Assert.IsTrue(response.Status == "success");

            var guild = response.Data.FirstOrDefault();
            Assert.IsTrue(guild.Id == "E8C6fp");
            Assert.IsTrue(guild.Name == "St. Louis Brewers Guild");
        }
    }
}
