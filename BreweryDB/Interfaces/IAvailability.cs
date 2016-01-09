namespace BreweryDB.Interfaces
{
    public interface IAvailable 
    {
        string Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}