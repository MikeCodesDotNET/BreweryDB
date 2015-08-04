using System;

namespace BreweryDB.Models
{
    public class Adjunct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string CategoryDisplay { get; set; }

        public DateTime CreateDate { get; set; }
    }
}

