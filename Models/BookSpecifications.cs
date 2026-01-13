using System.Text.Json.Serialization;

public class BookSpecifications
{
    [JsonPropertyName("Author")]
    public string Author { get; set; } = string.Empty;
}