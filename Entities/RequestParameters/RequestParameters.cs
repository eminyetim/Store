namespace Entities.RequestParameters
{
    public abstract class RequestParameters
    {
        public string? searchTerm { get; set; } // SearhTerm tüm aramalarda olucağı için ortak kullanabiliriz.
    }
}