using BuscadorDeLivros.Models;
using BuscadorDeLivros.Repositories;
using Newtonsoft.Json;

namespace BuscadorDeLivros.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private IList<Book>? _books;
        
        public BooksRepository() {
            _books = CarregarBooks();
        }

        private IList<Book>? CarregarBooks()
        {
            var fileName = "books.json";
            var folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            var filePath = Path.Combine(folderPath, fileName);

            try
            {
                using StreamReader reader = new(filePath);
                string jsonContent = reader.ReadToEnd();
                return _books = JsonConvert.DeserializeObject<List<Book>>(jsonContent);
            }
            catch (Exception ex)
            {
                // log
                return null;
            }
        }

        public List<Book>? BuscarTodos()
        {
            return _books?.ToList();
        }

        public Book? BuscarPorId(int id)
        {
            return _books?.FirstOrDefault(b=>b.Id == id);
        }
    }
}
