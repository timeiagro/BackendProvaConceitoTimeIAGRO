using System.Text.Json.Serialization;

namespace Hamurabi.Core.Models
{
    // Especificações detalhadas de um livro
    public class BookSpecifications
    {
        [JsonPropertyName("Originally published")]
        public string? OriginallyPublished { get; set; }

        [JsonPropertyName("Author")]
        public string? Author { get; set; }

        [JsonPropertyName("Page count")]
        public int PageCount { get; set; }

        [JsonPropertyName("Illustrator")]
        public object? Illustrator { get; set; }

        [JsonPropertyName("Genres")]
        public object? Genres { get; set; }
    }
}