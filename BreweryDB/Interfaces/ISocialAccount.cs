namespace BreweryDB.Interfaces
{
    public interface ISocialAccount
    {
        string Id { get; set; }
        string SocialMediaId { get; set; }
        ISocialMedia SocialMedia { get; set; }
        string Handle { get; set; }
        string CreateDate { get; set; }
        string Link { get; set; }
    }
}