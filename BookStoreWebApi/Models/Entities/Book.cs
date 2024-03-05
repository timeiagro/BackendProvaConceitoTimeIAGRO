using Newtonsoft.Json;

namespace BookStoreWebApi.Models.Entities
{
    public class Book
    {

        [JsonProperty("Id")]
        public int Id;

        [JsonProperty("Name")]
        public string Name;

        [JsonProperty("Price")]
        public double Price;

        [JsonProperty("Specifications")]
        public Specification Specifications;
    }
}
