using BookCatalogApi.Models;
using System.Text.Json;

namespace BookCatalogApi.Repository;

public class JsonBookRepository : IBookRepository
{
    private readonly List<Book> _books;

    public JsonBookRepository(string jsonFilePath)
    {
        if (string.IsNullOrEmpty(jsonFilePath))
            throw new ArgumentNullException(nameof(jsonFilePath));

        if (!File.Exists(jsonFilePath))
            throw new FileNotFoundException($"JSON file not found: {jsonFilePath}");

        var json = File.ReadAllText(jsonFilePath);
        _books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
    }

    public IEnumerable<Book> GetAll() => _books.AsReadOnly();

    public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);
}
