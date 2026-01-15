using System.Text.Json;
using Arbooks.Business.DTOs;
using Arbooks.Business.Repository.Interface;
using static System.Reflection.Metadata.BlobBuilder;

namespace Arbooks.Business.Repository
{
    public class BookRepository : IBookRepository
    {
        public BookRepository()
        {
        }

        public List<BookDTO> Load()
        {
        var jsonContent = File.ReadAllText("..\\Arbooks.Business\\books.json");
            var listBook = JsonSerializer.Deserialize<List<BookDTO>>(jsonContent);

            return listBook;
        }
    }
}