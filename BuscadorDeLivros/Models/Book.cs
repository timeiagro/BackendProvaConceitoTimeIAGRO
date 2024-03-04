namespace BuscadorDeLivros.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public BookSpecifications Specifications { get; set; } = new();
    }
}
