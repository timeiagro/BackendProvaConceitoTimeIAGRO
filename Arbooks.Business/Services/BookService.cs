using Arbooks.Business.DTOs;
using Arbooks.Business.Repository.Interface;

namespace Arbooks.Business.Services
{
    public class BookService
    {
        IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        public List<BookDTO> Search(string? term, string? order)
        {
            var bookList = _bookRepository.Load();

            if (!string.IsNullOrWhiteSpace(term))
            {
                bookList = bookList
                .Where(book =>
                    book.name.Contains(term, StringComparison.OrdinalIgnoreCase)
                    || (book.specifications != null &&
                        (book.specifications.author.Contains(term, StringComparison.OrdinalIgnoreCase)
                          || book.specifications.illustrator.ToString().Contains(term, StringComparison.OrdinalIgnoreCase)
                          || book.specifications.genres.ToString().Contains(term, StringComparison.OrdinalIgnoreCase)
                        )
                    )
                )
                .ToList();
            }

            bookList = order switch
            {
                "priceAsc" => bookList.OrderBy(book => book.price).ToList(),
                "priceDesc" => bookList.OrderByDescending(book => book.price).ToList(),
                _ => bookList
            };

            return bookList;
        }

        public BookDTO Details(int id)
        {
            var book = _bookRepository
                .Load()
                .FirstOrDefault(book => book.id == id);
            return book;
        }
    }
}
