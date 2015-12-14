using BreweryDB.Interfaces;

namespace BreweryDB.Models
{
    public class Images : IImages
    {
        public string Icon { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
    }
}