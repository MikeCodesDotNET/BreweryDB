using BreweryDB.Interfaces;

namespace BreweryDB.Models
{
    public class FluidSize : IFluidSize
    {
        public string Id { get; set; }
        public string Volume { get; set; }
        public string VolumeDisplay { get; set; }
        public string Quantity { get; set; }
    }
}
