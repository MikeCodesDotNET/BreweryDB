using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryDB.Interfaces
{
    public interface IGuild
    {
        string Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Established { get; set; }
        string Website { get; set; }
        IImages Images { get; set; }
        string Status { get; set; }
        string StatusDisplay { get; set; }
    }
}
