using System.Text.Json;
using Hamurabi.Core.Interfaces;
using Hamurabi.Core.Models;

namespace Hamurabi.Core.Repositories
{
    // Implementação do repositório que lê livros do arquivo JSON
    public class BookRepository : IBookRepository
    {
        private readonly string _jsonFilePath;
        private List<Book>? _cachedBooks;

        public BookRepository(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }

        // Retorna todos os livros do catálogo
        public List<Book> GetAllBooks()
        {
            if (_cachedBooks != null)
            {
                return _cachedBooks;
            }

            if (!File.Exists(_jsonFilePath))
            {
                throw new FileNotFoundException($"Arquivo JSON não encontrado: {_jsonFilePath}");
            }

            string jsonContent = File.ReadAllText(_jsonFilePath);

            // Configurar opções de deserialização
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, // Ignora diferença entre maiúsculas/minúsculas
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Espera camelCase
            };

            _cachedBooks = JsonSerializer.Deserialize<List<Book>>(jsonContent, options);

            return _cachedBooks ?? new List<Book>();
        }
    }
}