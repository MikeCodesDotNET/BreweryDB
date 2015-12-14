using BreweryDB.Interfaces;

namespace BreweryDB.Models
{
    public class Glass : IGlass
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CreateDate { get; set; }
    }
}