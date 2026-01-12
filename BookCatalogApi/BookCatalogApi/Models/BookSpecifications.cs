using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookCatalogApi.Models;

public class BookSpecifications
{
    [JsonPropertyName("Originally published")]
    public string? OriginallyPublished { get; set; }

    [JsonPropertyName("Author")]
    public string? Author { get; set; }

    [JsonPropertyName("Page count")]
    public int? PageCount { get; set; }

    [JsonPropertyName("Illustrator")]
    public JsonElement? Illustrator { get; set; }

    [JsonPropertyName("Genres")]
    public JsonElement? Genres { get; set; }

    private static IEnumerable<string> JsonElementToList(JsonElement? element)
    {
        if (element is null || element.Value.ValueKind == JsonValueKind.Null)
            return Enumerable.Empty<string>();

        if (element.Value.ValueKind == JsonValueKind.String)
            return new[] { element.Value.GetString() ?? string.Empty };

        if (element.Value.ValueKind == JsonValueKind.Array)
            return element.Value.EnumerateArray()
                .Select(e => e.GetString() ?? string.Empty)
                .Where(s => !string.IsNullOrEmpty(s));

        return Enumerable.Empty<string>();
    }

    public IEnumerable<string> GetIllustrators() => JsonElementToList(Illustrator);
    public IEnumerable<string> GetGenres() => JsonElementToList(Genres);
}
