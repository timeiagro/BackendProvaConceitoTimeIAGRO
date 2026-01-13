using Hamurabi.Core.Models;

namespace Hamurabi.Core.Interfaces
{

    // Contrato para operações de busca e manipulação de livros

    public interface IBookService
    {
        
        // Busca livros por qualquer especificação (autor, nome, etc)
    
        // <param name="searchTerm">Termo de busca</param>
        // <returns>Lista de livros encontrados</returns>
        List<Book> SearchBooks(string searchTerm);

        
        // Ordena livros por preço
    
        // <param name="books">Lista de livros</param>
        // <param name="ascending">true = ascendente, false = descendente</param>
        // <returns>Lista ordenada</returns>
        List<Book> OrderByPrice(List<Book> books, bool ascending = true);

        
        // Retorna todos os livros
        List<Book> GetAllBooks();
    }
}