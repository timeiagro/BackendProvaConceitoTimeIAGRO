using Newtonsoft.Json;

namespace BookStoreWebApi.Models.Entities
{
    public class Book
    {

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Price")]
        public double Price { get; set; }

        [JsonProperty("Specifications")]
        public Specification Specifications { get; set; }
    }
}
