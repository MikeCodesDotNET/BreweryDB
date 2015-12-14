namespace BreweryDB.Interfaces
{
    public interface ILocation
    {
        string Id { get; set; }
        string Mame { get; set; }
        string IsPrimary { get; set; }
        string InPlanning { get; set; }
        string IsClosed { get; set; }
        string OpenToPublic { get; set; }
        string LocationType { get; set; }
        string LocationTypeDisplay { get; set; }
        string CountryIsoCode { get; set; }
        string Status { get; set; }
        string StatusDisplay { get; set; }
        string CreateDate { get; set; }
        string UpdateDate { get; set; }
        ICountry Country { get; set; }
        string StreetAddress { get; set; }
        string Locality { get; set; }
        string Region { get; set; }
        string Phone { get; set; }
        double? Latitude { get; set; }
        double? Longitude { get; set; }
        string PostalCode { get; set; }
        string Website { get; set; }
        string HoursOfOperation { get; set; }
        string YearOpened { get; set; }
        string OpenTo { get; set; }
    }
}