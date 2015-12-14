using BreweryDB.Interfaces;

namespace BreweryDB.Models
{
    public class SocialSite : ISocialSite
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
    }
}