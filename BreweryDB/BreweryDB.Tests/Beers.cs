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
        public async void ById()
        {
            var response = await client.Beers.Get("cBLTUw");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.Message == "Request Successful");

            var beer = response.Data;
            Assert.IsTrue(beer.Name == "\"18\" Imperial IPA 2");
            Assert.IsTrue(beer.NameDisplay == "\"18\" Imperial IPA 2");
            Assert.IsTrue(beer.Description == "Hop Heads this one's for you!  Checking in with 143 IBU's this ale punches you in the mouth with extreme bitterness then rounds out with toffee flavors and finishes with a citrus aroma.  Made with tons of US 2 Row Barley to get this to ABV 11.1%.");
            Assert.IsTrue(beer.Abv == 11.1);

            //SRM
            Assert.IsTrue(beer.SrmId == 33);
            Assert.IsTrue(beer.Srm.Id == "33");
            Assert.IsTrue(beer.Srm.Name == "33");
            Assert.IsTrue(beer.Srm.Hex == "520907");

            //Available
            Assert.IsTrue(beer.AvailableId == 1);
            Assert.IsTrue(beer.Available.Id == "1");
            Assert.IsTrue(beer.Available.Name == "Year Round");
            Assert.IsTrue(beer.Available.Description == "Available year round as a staple beer.");

            //Brewery
            Assert.IsTrue(beer.Brewery == "Ship Bottom Brewery");
            var brewery = beer.Breweries?.FirstOrDefault();
            Assert.IsTrue(brewery.Description.Contains("Our humble beginnings started in the Summer of 1995") == true);
            Assert.IsTrue(brewery.Id == "qa1QZU");

            //Style
            Assert.IsTrue(beer.StyleId == 43);
            Assert.IsTrue(beer.Style.Id == "43");
            Assert.IsTrue(beer.Style.CategoryId == "3");
            Assert.IsTrue(beer.Style.Name == "American-Style Imperial Stout");
            Assert.IsTrue(beer.Style.Description == "Black in color, American-style imperial stouts typically have a high alcohol content. Generally characterized as very robust. The extremely rich malty flavor and aroma are balanced with assertive hopping and fruity-ester characteristics. Bitterness should be moderately high to very high and balanced with full sweet malt character. Roasted malt astringency and bitterness can be moderately perceived but should not overwhelm the overall character. Hop aroma is usually moderately-high to overwhelmingly hop-floral, -citrus or -herbal. Diacetyl (butterscotch) levels should be absent.");
            Assert.IsTrue(beer.Style.IbuMin == 50);
            Assert.IsTrue(beer.Style.IbuMax == 80);
            Assert.IsTrue(beer.Style.AbvMin == 7);
            Assert.IsTrue(beer.Style.AbvMax == 12);
            Assert.IsTrue(beer.Style.SrmMin == 40);
            Assert.IsTrue(beer.Style.SrmMax == 40);
            Assert.IsTrue(beer.Style.OgMin == 1.08);
            Assert.IsTrue(beer.Style.FgMin == 1.02);
            Assert.IsTrue(beer.Style.FgMax == 1.03);

            //Category
            Assert.IsTrue(beer.Style.Category.Id == "3");
            Assert.IsTrue(beer.Style.Category.Name == "North American Origin Ales");

            Assert.IsTrue(beer.IsOrganic == "N");
            Assert.IsTrue(beer.Status == "verified");


            //Glass
            Assert.IsTrue(beer.GlasswareId == 5);
            Assert.IsTrue(beer.Glass.Name == "Pint");
            Assert.IsTrue(beer.Glass.Id == "5");

        }

        [Test()]
        public void GetAll()
        {
            var response = client.Beers.GetAll().Result;

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 1);
            Assert.IsTrue(response.NumberOfPages >= 1018);
            Assert.IsTrue(response.TotalResults >= 50892);

            var beer = response.Data.FirstOrDefault();
            Assert.IsTrue(beer.Name == "\"18\" Imperial IPA 2");
            Assert.IsTrue(beer.NameDisplay == "\"18\" Imperial IPA 2");
            Assert.IsTrue(beer.Description == "Hop Heads this one's for you!  Checking in with 143 IBU's this ale punches you in the mouth with extreme bitterness then rounds out with toffee flavors and finishes with a citrus aroma.  Made with tons of US 2 Row Barley to get this to ABV 11.1%.");
            Assert.IsTrue(beer.Abv == 11.1);

            //Breweries
            Assert.IsTrue(beer.Breweries != null);

            //SRM
            Assert.IsTrue(beer.SrmId == 33);
            Assert.IsTrue(beer.Srm.Id == "33");
            Assert.IsTrue(beer.Srm.Name == "33");
            Assert.IsTrue(beer.Srm.Hex == "520907");

            //Available
            Assert.IsTrue(beer.AvailableId == 1);
            Assert.IsTrue(beer.Available.Id == "1");
            Assert.IsTrue(beer.Available.Name == "Year Round");
            Assert.IsTrue(beer.Available.Description == "Available year round as a staple beer.");

            //Style
            Assert.IsTrue(beer.StyleId == 43);
            Assert.IsTrue(beer.Style.Id == "43");
            Assert.IsTrue(beer.Style.CategoryId == "3");
            Assert.IsTrue(beer.Style.Name == "American-Style Imperial Stout");
            Assert.IsTrue(beer.Style.Description == "Black in color, American-style imperial stouts typically have a high alcohol content. Generally characterized as very robust. The extremely rich malty flavor and aroma are balanced with assertive hopping and fruity-ester characteristics. Bitterness should be moderately high to very high and balanced with full sweet malt character. Roasted malt astringency and bitterness can be moderately perceived but should not overwhelm the overall character. Hop aroma is usually moderately-high to overwhelmingly hop-floral, -citrus or -herbal. Diacetyl (butterscotch) levels should be absent.");
            Assert.IsTrue(beer.Style.IbuMin == 50);
            Assert.IsTrue(beer.Style.IbuMax == 80);
            Assert.IsTrue(beer.Style.AbvMin == 7);
            Assert.IsTrue(beer.Style.AbvMax == 12);
            Assert.IsTrue(beer.Style.SrmMin == 40);
            Assert.IsTrue(beer.Style.SrmMax == 40);
            Assert.IsTrue(beer.Style.OgMin == 1.08);
            Assert.IsTrue(beer.Style.FgMin == 1.02);
            Assert.IsTrue(beer.Style.FgMax == 1.03);

            //Category
            Assert.IsTrue(beer.Style.Category.Id == "3");
            Assert.IsTrue(beer.Style.Category.Name == "North American Origin Ales");

            Assert.IsTrue(beer.IsOrganic == "N");
            Assert.IsTrue(beer.Status == "verified");


            //Glass
            Assert.IsTrue(beer.GlasswareId == 5);
            Assert.IsTrue(beer.Glass.Name == "Pint");
            Assert.IsTrue(beer.Glass.Id == "5");

        }

        [Test()]
        public async void GetPage()
        {
            var response = await client.Beers.GetAll(4);

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 4);
            Assert.IsTrue(response.NumberOfPages >= 1018);
            Assert.IsTrue(response.TotalResults >= 50892);

            var beer = response.Data.FirstOrDefault();
            Assert.IsNotNull(beer);
        }

        [Test()]
        public async void GetWithParameters()
        {
            var parameters = new NameValueCollection {{BeerRequestParameters.Name, "duvel single"}};
            var response = await client.Beers.Get(parameters);

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 1);
            Assert.IsTrue(response.NumberOfPages >= 1);
            Assert.IsTrue(response.TotalResults >= 1);

            var beer = response.Data.FirstOrDefault();
            Assert.IsTrue(beer?.Id == "c8VKLu");
            Assert.IsTrue(beer.Name == "Duvel Single");
        }

        [Test()]
        public async void Search()
        {
            var response = await client.Beers.Search("duvel");

            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 1);
            Assert.IsTrue(response.NumberOfPages >= 1);
            Assert.IsTrue(response.TotalResults >= 6);

            var beer = response.Data.FirstOrDefault();
            Assert.IsTrue(beer?.Id == "tAmjew");
            Assert.IsTrue(beer.Name == "Duvel Green");
        }

        [Test()]
        public async void CustomType()
        {
            var newClient = new BreweryDbClient(Keys.ApplicationKey);
            var Beers = new BeerResource<MyBeer>(newClient);
            
            var response = await Beers.GetAll();
            
            Assert.IsTrue(response.Status == "success");
            Assert.IsTrue(response.CurrentPage == 1);
            Assert.IsTrue(response.NumberOfPages >= 1);
            Assert.IsTrue(response.TotalResults >= 1019);

            var beer = response.Data.FirstOrDefault();
            Assert.IsTrue(beer?.Id == "cBLTUw");
        }

        [Test()]
        public async void HasImages()
        {
            var response = await client.Beers.Search("Stella");

            Assert.IsTrue(response.Status == "success");

            var beer = response.Data.FirstOrDefault(x => x.Id == "Jc7iGI");
            Assert.IsNotNull(beer.Labels);
        }
    }
}
