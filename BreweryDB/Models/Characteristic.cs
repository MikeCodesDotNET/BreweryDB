using BreweryDB.Interfaces;

namespace BreweryDB.Models
{
    public class Characteristic : ICharacteristic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
