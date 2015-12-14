using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryDB.Models.RequestParameters
{
    public class BeerRequestParameters
    {
        public static readonly string Page = "p";
        public static readonly string Name = "name";

        public static readonly string Abv = "abv";
        public static readonly string Ibu = "ibu";
        public static readonly string GlasswareId = "glasswareId";
        public static readonly string SrmId = "srmID";
        public static readonly string AvailableId = "availableId";
        public static readonly string StyleId = "styleId";
        public static readonly string IsOrganic = "isOrganic";
        public static readonly string HasLabels = "hasLabels";
        public static readonly string Year = "year";
        public static readonly string Since = "since";
        public static readonly string Status = "status";
        public static readonly string WithBreweries = "withBreweries";
        public static readonly string WithSocialAccounts = "withSocialAccounts";
        public static readonly string WithIngredients = "withIngredients";
    }
}
