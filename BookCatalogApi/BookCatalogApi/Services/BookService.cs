using BookCatalogApi.Dtos;
using BookCatalogApi.Models;
using BookCatalogApi.Repository;

namespace BookCatalogApi.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    private const decimal DefaultShippingPercentage = 0.20m;

    public BookService(IBookRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public decimal CalculateShipping(int bookId)
    {
        var book = _repository.GetById(bookId);
        
        if (book is null)
            throw new KeyNotFoundException($"Book with id {bookId} not found");

        return book.CalculateShippingCost(DefaultShippingPercentage);
    }

    public BookResponse? GetById(int id)
    {
        var book = _repository.GetById(id);
        return book != null ? MapToResponse(book) : null;
    }

    public IEnumerable<BookResponse> Search(BookSearchRequest request)
    {
        var books = _repository.GetAll();

        books = ApplyFilters(books, request);
        books = ApplySorting(books, request);

        return books.Select(MapToResponse);
    }

    private static IEnumerable<Book> ApplyFilters(IEnumerable<Book> books, BookSearchRequest request)
    {
        if (!string.IsNullOrWhiteSpace(request.Name))
        {
            books = books.Where(b =>
                b.Name.Contains(request.Name, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(request.Author))
        {
            books = books.Where(b =>
                b.Specifications.Author != null &&
                b.Specifications.Author.Contains(request.Author, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(request.Genre))
        {
            books = books.Where(b =>
                b.Specifications.GetGenres()
                    .Any(g => g.Contains(request.Genre, StringComparison.OrdinalIgnoreCase)));
        }

        if (!string.IsNullOrWhiteSpace(request.Illustrator))
        {
            books = books.Where(b =>
                b.Specifications.GetIllustrators()
                    .Any(i => i.Contains(request.Illustrator, StringComparison.OrdinalIgnoreCase)));
        }

        if (!string.IsNullOrWhiteSpace(request.Query))
        {
            var query = request.Query;
            books = books.Where(b =>
                b.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                (b.Specifications.Author?.Contains(query, StringComparison.OrdinalIgnoreCase) ?? false) ||
                b.Specifications.GetGenres().Any(g => g.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                b.Specifications.GetIllustrators().Any(i => i.Contains(query, StringComparison.OrdinalIgnoreCase)));
        }

        return books;
    }

    private static IEnumerable<Book> ApplySorting(IEnumerable<Book> books, BookSearchRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.SortBy))
            return books;

        var isDescending = request.SortOrder?.Equals("desc", StringComparison.OrdinalIgnoreCase) ?? false;

        return request.SortBy.ToLowerInvariant() switch
        {
            "price" => isDescending
                ? books.OrderByDescending(b => b.Price)
                : books.OrderBy(b => b.Price),
            "name" => isDescending
                ? books.OrderByDescending(b => b.Name)
                : books.OrderBy(b => b.Name),
            _ => books
        };
    }

    private static BookResponse MapToResponse(Book book)
    {
        return new BookResponse
        {
            Id = book.Id,
            Name = book.Name,
            Price = book.Price,
            ShippingCost = book.CalculateShippingCost(DefaultShippingPercentage),
            Specifications = new BookSpecificationResponse
            {
                OriginallyPublished = book.Specifications.OriginallyPublished,
                Author = book.Specifications.Author,
                PageCount = book.Specifications.PageCount,
                Illustrators = book.Specifications.GetIllustrators(),
                Genres = book.Specifications.GetGenres()    
            }
        };
    }
}
