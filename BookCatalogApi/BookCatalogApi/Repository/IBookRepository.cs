using BookCatalogApi.Models;

namespace BookCatalogApi.Repository;

public interface IBookRepository
{
    IEnumerable<Book> GetAll();
    Book? GetById(int id);
}
