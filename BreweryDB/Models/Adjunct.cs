using System;
using BreweryDB.Interfaces;

namespace BreweryDB.Models
{
    public class Adjunct : IAdjunct
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string CategoryDisplay { get; set; }
        public DateTime CreateDate { get; set; }
    }
}