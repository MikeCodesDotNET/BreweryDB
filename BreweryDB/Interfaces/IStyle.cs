using BreweryDB.Models;

namespace BreweryDB.Interfaces
{
    public interface IStyle
    {
        string Id { get; set; }
        string CategoryId { get; set; }
        ICategory Category { get; set; }
        string Name { get; set; }
        string ShortName { get; set; }
        string Description { get; set; }
        double IbuMin { get; set; }
        double IbuMax { get; set; }
        double AbvMin { get; set; }
        double AbvMax { get; set; }
        double SrmMin { get; set; }
        double SrmMax { get; set; }
        double OgMin { get; set; }
        double FgMin { get; set; }
        double FgMax { get; set; }
        string CreateDate { get; set; }
        string UpdateDate { get; set; }
    }
}