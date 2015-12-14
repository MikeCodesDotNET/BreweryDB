namespace BreweryDB.Interfaces
{
    public interface ICategory
    {
        string Id { get; set; }
        string Name { get; set; }
        string CreateDate { get; set; }
        string Description { get; set; }
    }
}