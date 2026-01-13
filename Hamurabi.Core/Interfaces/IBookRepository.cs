using Hamurabi.Core.Models;

namespace Hamurabi.Core.Interfaces
{
    ///Contrato para operações de leitura do catálogo de livros
    public interface IBookRepository
    {
        // Retorna todos os livros do catálogo
        List<Book> GetAllBooks();
    }
}