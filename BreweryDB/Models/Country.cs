using System;

namespace BreweryDB.Models
{
    public class Country
    {
        public string IsoCode { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string IsoThree { get; set; }
        public int NumberCode { get; set; }
        public string CreateDate { get; set; }
    }
}

