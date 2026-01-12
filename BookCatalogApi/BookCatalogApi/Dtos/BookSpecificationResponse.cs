namespace BookCatalogApi.Dtos;

public class BookSpecificationResponse
{
    public string? OriginallyPublished { get; set; }
    public string? Author { get; set; }
    public int? PageCount { get; set; }
    public IEnumerable<string> Illustrators { get; set; } = [];
    public IEnumerable<string> Genres { get; set; } = [];
}
