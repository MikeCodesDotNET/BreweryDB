using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryDB.Interfaces
{
    public interface IGlass 
    {
        string Id { get; set; }
        string Name { get; set; }
        string CreateDate { get; set; }
    }
}
