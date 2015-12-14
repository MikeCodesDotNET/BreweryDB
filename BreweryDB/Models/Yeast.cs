using BreweryDB.Interfaces;

namespace BreweryDB.Models
{
    public class Yeast : IYeast
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string CategoryDisplay { get; set; }
    }
}