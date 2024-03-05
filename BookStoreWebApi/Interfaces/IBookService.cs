using BookStoreWebApi.Models.Entities;

namespace BookStoreWebApi.Interfaces
{
    public interface IBookService
    {
        List<Book> GetByName(string name);

        List<Book> ListBooks(bool? order);

        List<Book> GetByAuthor(string author, bool? order);

        List<Book> GetByGenre(string genre, bool? order);

        List<Book> GetByPrice(double price, bool? order);

        List<Book> GetByDate(string date, bool? order);

        List<Book> GetByPageCount(int pageCount, bool? order);

        List<Book> GetByIllustrator(string illustrator, bool? order);

        double CalculateShipping(string bookName);
    }
}
