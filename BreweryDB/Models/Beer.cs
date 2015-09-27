using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryDB.Models
{
    public class Beer
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Abv { get; set; }

        public int GlasswareId { get; set; }

        public int SrmId { get; set; }

        public int AvailableId { get; set; }

        public int StyleId { get; set; }

        public string IsOrganic { get; set; }

        public string Status { get; set; }

        public string StatusDisplay { get; set; }

        public string CreateDate { get; set; }

        public string UpdateDate { get; set; }

        public Glass Glass { get; set; }

        public Srm Srm { get; set; }

        public Available Available { get; set; }

        public Style Style { get; set; }

        public List<Brewery> Breweries { get; set; }

        public Labels Labels { get; set; }

        public string ServingTemperature { get; set; }

        public string Brewery { get; set; }
    }
}
