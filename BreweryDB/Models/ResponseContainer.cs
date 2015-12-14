namespace BreweryDB.Models
{
    public class ResponseContainer<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
        public string Status { get; set; }
        public int CurrentPage { get; set; }
        public int NumberOfPages { get; set; }
        public int TotalResults;
    }
}
