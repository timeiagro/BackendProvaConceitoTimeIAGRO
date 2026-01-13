using System.Text.Json;
using CatalogoLivros.Api.Models;
//Responsavel pela leitura do arquivo books.json e transformar em lista.
namespace CatalogoLivros.Api.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public BookRepository()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Data", "books.json");
            var json = File.ReadAllText(path);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            _books = JsonSerializer.Deserialize<List<Book>>(json, options)
                     ?? new List<Book>();
        }

        public List<Book> GetAll() => _books;

        public Book? GetById(long id)
            => _books.FirstOrDefault(b => b.Id == id);
    }
}