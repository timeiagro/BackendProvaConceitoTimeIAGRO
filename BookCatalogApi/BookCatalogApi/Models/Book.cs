using System.Text.Json.Serialization;

namespace BookCatalogApi.Models;

public class Book
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("specifications")]
    public BookSpecifications Specifications { get; set; } = new();

    public decimal CalculateShippingCost(decimal percentage = 0.20m)
    {
        if (percentage < 0)
            throw new ArgumentException("Percentage cannot be negative.", nameof(percentage));

        return Math.Round(Price * percentage, 2);
    }
}
