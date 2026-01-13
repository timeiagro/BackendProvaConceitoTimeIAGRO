using System.Text.Json.Serialization;
  //Apenas os dados sem regras.
namespace CatalogoLivros.Api.Models
{
    public class Book
    {    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Title { get; set; } = string.Empty;

    public double Price { get; set; }

    [JsonPropertyName("specifications")]
    public BookSpecifications Specifications { get; set; } = new();
}
}