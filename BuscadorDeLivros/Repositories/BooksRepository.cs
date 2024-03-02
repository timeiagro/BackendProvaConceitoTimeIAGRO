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

        public async Task<List<Book>>? BuscarTodosAsync()
        {
            try
            {
                using StreamReader reader = new StreamReader(_booksFilePath);
                string jsonContent = await reader.ReadToEndAsync();
                var books = JsonConvert.DeserializeObject<List<Book>>(jsonContent);
                return books;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao ler arquivo JSON de Books", ex); 
            }
        }

        public async Task<Book>? BuscarPorIdAsync(int id)
        {
            return (await BuscarTodosAsync()).FirstOrDefault(b=>b.Id == id);
        }
    }
}
