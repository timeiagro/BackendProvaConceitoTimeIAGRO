namespace BookCatalogApi.Dtos;

public class BookSearchRequest
{
    public string? Name { get; set; }
    public string? Author { get; set; }
    public string? Genre { get; set; }
    public string? Illustrator { get; set; }
    public string? Query { get; set; }
    public string? SortBy { get; set; }
    public string? SortOrder { get; set; }
}
