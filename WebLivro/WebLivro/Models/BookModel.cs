using Newtonsoft.Json;

namespace WebLivros.Models;

public class BookModel
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("price")]
    public double Price { get; set; }
    [JsonProperty("specifications")]
    public SpecificationsModel Specifications { get; set; }
    public double CalculateFee() => (Price * 20) / 100;
}
