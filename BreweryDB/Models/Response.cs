using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryDB.Models
{
    public class Response
    {
        public string Message { get; set; }
        public Object Data { get; set; }
        public string Status { get; set; }
    }
}
