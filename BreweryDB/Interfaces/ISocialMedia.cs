using System;

namespace BreweryDB.Interfaces
{
    public interface ISocialMedia
    {
        string Id { get; set; }
        string Website { get; set; }
        DateTime CreateDate { get; set; }
        string Name { get; set; }
    }
}