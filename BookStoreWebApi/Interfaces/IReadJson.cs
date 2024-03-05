using BookStoreWebApi.Models.Entities;

namespace BookStoreWebApi.Interfaces
{
    public interface IReadJson
    {
        List<Book> ReadBookList();
    }
}
