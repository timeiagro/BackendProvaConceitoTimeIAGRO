using BuscadorDeLivros.Models;
using BuscadorDeLivros.Repositories;
using Newtonsoft.Json;

namespace BuscadorDeLivros.Repository
{
    public class BookRepository : IBookRepository
    {
        public List<Book>? BuscarTodos()
        {
            try
            {
                var execututionDirectory = AppContext.BaseDirectory;
                var directoryProject = Path.GetFullPath(Path.Combine(execututionDirectory, @"..\..\..\.."));
                var filePath = Path.Combine(directoryProject, "books.json");
                using StreamReader reader = new StreamReader(filePath);
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
