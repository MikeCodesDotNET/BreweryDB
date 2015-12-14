using System;
using BreweryDB.Interfaces;

namespace BreweryDB.Models
{
    public class Labels : ILabels
    {
        public string Icon { get; set; }

        public string Medium { get; set; }

        public string Large { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}