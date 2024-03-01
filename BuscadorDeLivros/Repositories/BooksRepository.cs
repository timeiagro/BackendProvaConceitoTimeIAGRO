using BuscadorDeLivros.Models;
using BuscadorDeLivros.Repositories;
using Newtonsoft.Json;

namespace BuscadorDeLivros.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly string _booksFilePath;
        
        public BooksRepository() {
            var execututionDirectory = AppContext.BaseDirectory;
            var directoryProject = Path.GetFullPath(Path.Combine(execututionDirectory, @"..\..\..\.."));
            _booksFilePath = Path.Combine(directoryProject, "books.json");
        }

        public List<Book>? BuscarTodos()
        {
            try
            {
                using StreamReader reader = new StreamReader(_booksFilePath);
                string jsonContent = reader.ReadToEnd();
                var books = JsonConvert.DeserializeObject<List<Book>>(jsonContent);
                return books;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao ler arquivo JSON de Books", ex); 
            }
        }

        public Book? BuscarPorId(int id)
        {
            return BuscarTodos()?.FirstOrDefault(b=>b.Id == id);
        }
    }
}
