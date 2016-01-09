using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryDB.Models
{
    public class SubAttribute
    {
        public Brewery Brewery { get; set; }
        public int? Id { get; set; }
        public int? SocialMediaId { get; set; }
        public SocialMedia SocialMedia { get; set; }
        public string Handle { get; set; }
        public string CreateDate { get; set; }
        public string Link { get; set; }
        public string BreweryId { get; set; }
        public string BeerId { get; set; }
        public Beer Beer { get; set; }
    }
}
