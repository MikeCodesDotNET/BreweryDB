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
    public class FluidSizes
    {
        private readonly BreweryDbClient client = new BreweryDbClient(Keys.ApplicationKey);

        [Test()]
        public async Task ById()
        {
            var response = await client.FluidSizes.Get("1");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.Message == "Request Successful");

            var fluidSize = response.Data;
            Assert.IsTrue(fluidSize.Id == "1");
            Assert.IsTrue(fluidSize.Volume == "oz");
            Assert.IsTrue(fluidSize.VolumeDisplay == "Ounce (oz)");
            Assert.IsTrue(fluidSize.Quantity == "22");

        }

        [Test()]
        public async Task GetAll()
        {
            var response = await client.FluidSizes.GetAll();

            Assert.IsTrue(response.Status == "success");

            var fluidSize = response.Data.FirstOrDefault();
            Assert.IsTrue(fluidSize.Id == "1");
            Assert.IsTrue(fluidSize.Volume == "oz");
            Assert.IsTrue(fluidSize.VolumeDisplay == "Ounce (oz)");
            Assert.IsTrue(fluidSize.Quantity == "22");
        }
    }
}
