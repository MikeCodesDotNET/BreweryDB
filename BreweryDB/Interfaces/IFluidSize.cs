using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryDB.Interfaces
{
    public interface IFluidSize
    {
        string Id { get; set; }
        string Volume { get; set; }
        string VolumeDisplay { get; set; }
        string Quantity { get; set; }
    }
}
