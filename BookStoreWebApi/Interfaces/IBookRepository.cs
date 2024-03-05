using BookStoreWebApi.Models.Entities;

namespace BookStoreWebApi.Interfaces
{
    public interface IBookRepository
    {
        List<Book> ReadBookList();
    }
}
