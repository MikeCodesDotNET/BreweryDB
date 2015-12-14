
using BreweryDB.Interfaces;

namespace BreweryDB.Models
{
    public class Srm : ISrm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Hex { get; set; }
    }
}