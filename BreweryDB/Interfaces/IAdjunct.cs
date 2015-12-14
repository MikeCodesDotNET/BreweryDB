using System;

namespace BreweryDB.Interfaces
{
    public interface IAdjunct
    {
        string Id { get; set; }
        string Name { get; set; }
        string Category { get; set; }
        string CategoryDisplay { get; set; }
        DateTime CreateDate { get; set; }
    }
}