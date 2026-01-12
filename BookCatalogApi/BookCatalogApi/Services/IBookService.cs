using BookCatalogApi.Dtos;

namespace BookCatalogApi.Services;

public interface IBookService
{
    IEnumerable<BookResponse> Search(BookSearchRequest request);
    BookResponse? GetById(int id);
    decimal CalculateShipping(int bookId);
}
