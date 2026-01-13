using System.Text.Json;
using Hamurabi.Core.Interfaces;
using Hamurabi.Core.Models;

namespace Hamurabi.Core.Services
{
    // Implementação do serviço de busca e manipulação de livros
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // Retorna todos os livros
        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        // Busca livros por qualquer termo (nome, autor, gênero, etc)
        public List<Book> SearchBooks(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return GetAllBooks();
            }

            var allBooks = _bookRepository.GetAllBooks();
            var searchTermLower = searchTerm.ToLower();

            return allBooks.Where(book =>
                // Busca no nome do livro
                (book.Name?.ToLower().Contains(searchTermLower) ?? false) ||
                
                // Busca no autor
                (book.Specifications?.Author?.ToLower().Contains(searchTermLower) ?? false) ||
                
                // Busca na data de publicação
                (book.Specifications?.OriginallyPublished?.ToLower().Contains(searchTermLower) ?? false) ||
                
                // Busca nos gêneros
                SearchInGenres(book.Specifications?.Genres, searchTermLower) ||
                
                // Busca nos ilustradores
                SearchInIllustrators(book.Specifications?.Illustrator, searchTermLower)
            ).ToList();
        }

        // Ordena livros por preço
        public List<Book> OrderByPrice(List<Book> books, bool ascending = true)
        {
            if (ascending)
            {
                return books.OrderBy(b => b.Price).ToList();
            }
            else
            {
                return books.OrderByDescending(b => b.Price).ToList();
            }
        }

        // Busca em gêneros (pode ser string ou array)
        private bool SearchInGenres(object? genres, string searchTerm)
        {
            if (genres == null) return false;

            // Se for JsonElement (quando vem do JSON)
            if (genres is JsonElement jsonElement)
            {
                if (jsonElement.ValueKind == JsonValueKind.String)
                {
                    return jsonElement.GetString()?.ToLower().Contains(searchTerm) ?? false;
                }
                else if (jsonElement.ValueKind == JsonValueKind.Array)
                {
                    foreach (var item in jsonElement.EnumerateArray())
                    {
                        if (item.GetString()?.ToLower().Contains(searchTerm) ?? false)
                            return true;
                    }
                }
            }

            return false;
        }

        // Busca em ilustradores (pode ser string ou array)
        private bool SearchInIllustrators(object? illustrator, string searchTerm)
        {
            if (illustrator == null) return false;

            // Se for JsonElement (quando vem do JSON)
            if (illustrator is JsonElement jsonElement)
            {
                if (jsonElement.ValueKind == JsonValueKind.String)
                {
                    return jsonElement.GetString()?.ToLower().Contains(searchTerm) ?? false;
                }
                else if (jsonElement.ValueKind == JsonValueKind.Array)
                {
                    foreach (var item in jsonElement.EnumerateArray())
                    {
                        if (item.GetString()?.ToLower().Contains(searchTerm) ?? false)
                            return true;
                    }
                }
            }

            return false;
        }
    }
}