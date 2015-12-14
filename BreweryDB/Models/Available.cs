
using BreweryDB.Interfaces;

namespace BreweryDB.Models
{
    public class Available : IAvailable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}