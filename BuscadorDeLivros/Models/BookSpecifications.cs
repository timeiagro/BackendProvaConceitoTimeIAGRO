namespace BuscadorDeLivros.Models
{
    public class BookSpecifications
    {
        public string OriginallyPublished { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PageCount { get; set; } 
        public dynamic Illustrator { get; set; } = Array.Empty<string>();
        public dynamic Genres { get; set; } = Array.Empty<string>();
    }
}
