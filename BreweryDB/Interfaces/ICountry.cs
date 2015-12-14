namespace BreweryDB.Interfaces
{
    public interface ICountry
    {
        string CountryIsoCode { get; set; }
        string Name { get; set; }
        string DisplayName { get; set; }
        string IsoThree { get; set; }
        int NumberCode { get; set; }
        string CreateDate { get; set; }
    }
}