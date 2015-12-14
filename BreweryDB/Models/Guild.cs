using BreweryDB.Interfaces;

namespace BreweryDB.Models
{
    public class Guild : IGuild
    {
        public Guild(Images images)
        {
            Images = images;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Established { get; set; }
        public string Website { get; set; }
        public IImages Images { get; set; }
        public string Status { get; set; }
        public string StatusDisplay { get; set; }
    }
}
