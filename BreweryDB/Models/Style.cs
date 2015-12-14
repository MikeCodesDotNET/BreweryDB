
using BreweryDB.Helpers;
using BreweryDB.Interfaces;
using Newtonsoft.Json;

namespace BreweryDB.Models
{
    public class Style : IStyle
    {

        public Style(Category category)
        {
            Category = category;
        }

        public string Id { get; set; }
        public string CategoryId { get; set; }

        [JsonConverter(typeof(ConcreteConverter<Category>))]
        public ICategory Category { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public double IbuMin { get; set; }
        public double IbuMax { get; set; }
        public double AbvMin { get; set; }
        public double AbvMax { get; set; }
        public double SrmMin { get; set; }
        public double SrmMax { get; set; }
        public double OgMin { get; set; }
        public double FgMin { get; set; }
        public double FgMax { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
    }
}