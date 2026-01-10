using System.Text.Json;

namespace DesafioMiltec.Domain.Entities
{
    public sealed class BookSpecifications
    {
        public Dictionary<string, JsonElement> Values { get; init; } = [];
    }
}
