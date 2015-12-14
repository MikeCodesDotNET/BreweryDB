using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryDB.Models.RequestParameters
{
    public class BreweryRequestParameters
    {
        public static readonly string Page = "p";
        public static readonly string Name = "name";

        public static readonly string Established = "established";
        public static readonly string IsOrganic = "isOrganic";
        public static readonly string HasImages = "hasImages";
        public static readonly string Since = "since";
        public static readonly string Status = "status";
        public static readonly string WithSocialAccounts = "withSocialAccounts";
        public static readonly string WithGuilds = "withGuilds";
        public static readonly string WithLocations = "withLocations";
        public static readonly string WithAlternateNames = "withAlternateNames";
    }
}
