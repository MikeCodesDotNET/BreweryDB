using System.Diagnostics.Contracts;

namespace BreweryDB.Interfaces
{
    public interface IYeast
    {
        string Id { get; set; }
        string Name { get; set; }
        string Category { get; set; } 
        string CategoryDisplay { get; set; } 
    }
}