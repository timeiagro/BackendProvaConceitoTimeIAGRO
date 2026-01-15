using System.Text.Json.Serialization;

namespace Arbooks.Web.DTOs
{
    public class SpecificationDTO
    {
        [JsonPropertyName("Originally published")]
        public string originallyPublished { get; set; }

        [JsonPropertyName("Author")]
        public string author { get; set; }

        [JsonPropertyName("Page count")]
        public int pageCount { get; set; }

        [JsonPropertyName("Illustrator")]
        public object illustrator { get; set; }

        [JsonPropertyName("Genres")]
        public object genres { get; set; }
    }
}