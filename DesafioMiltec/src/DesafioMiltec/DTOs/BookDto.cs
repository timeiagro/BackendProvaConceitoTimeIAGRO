namespace DesafioMiltec.DTOs
{
    public sealed class BookDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public Dictionary<string, object?> Specifications { get; init; } = [];
    }
}
