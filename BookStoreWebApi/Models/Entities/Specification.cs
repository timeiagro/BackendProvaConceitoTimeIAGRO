using Newtonsoft.Json;

namespace BookStoreWebApi.Models.Entities
{
    public class Specification
    {
        [JsonProperty("Originally published")]
        public string Originallypublished { get; set; }

        [JsonProperty("Author")]
        public string Author { get; set; }

        [JsonProperty("Page count")]
        public int Pagecount { get; set; }

        [JsonProperty("Illustrator")]
        public object? Illustrator { get; set; }

        [JsonProperty("Genres")]
        public object? Genres { get; set; }
    }
}
