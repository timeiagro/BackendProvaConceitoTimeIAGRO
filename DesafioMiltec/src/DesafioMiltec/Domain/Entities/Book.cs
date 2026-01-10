using System.Text.Json;

namespace DesafioMiltec.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Dictionary<string, JsonElement> Specifications { get; init; } = [];
    }
}
