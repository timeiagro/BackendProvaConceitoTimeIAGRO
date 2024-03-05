using Newtonsoft.Json;

namespace BookStoreWebApi.Models.Entities
{
    public class Specification
    {
        [JsonProperty("Originally published")]
        public string Originallypublished;

        [JsonProperty("Author")]
        public string Author;

        [JsonProperty("Page count")]
        public int Pagecount;

        [JsonProperty("Illustrator")]
        public object? Illustrator;

        [JsonProperty("Genres")]
        public object? Genres;
    }
}
