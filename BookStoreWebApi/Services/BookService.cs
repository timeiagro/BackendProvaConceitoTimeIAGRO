using BookStoreWebApi.Interfaces;
using BookStoreWebApi.Models.Entities;
using Newtonsoft.Json.Linq;

namespace BookStoreWebApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository readJson)
        {
            _bookRepository = readJson ?? throw new ArgumentNullException(nameof(readJson));
        }

        public List<Book> GetByName(string name)
        {
            var booksList = _bookRepository.ReadBookList();
            return booksList.Where(x => x.Name?.ToLower().Contains(name?.ToLower()) == true).ToList();
        }

        public List<Book> ListBooks(bool? order)
        {
            var booksList = _bookRepository.ReadBookList();
            return OrderBooks(booksList, order);
        }

        private List<Book> OrderBooks(List<Book> books, bool? order)
        {
            return order == true ? books.OrderBy(x => x.Price).ToList() : books.OrderByDescending(x => x.Price).ToList();
        }

        public List<Book> GetByAuthor(string author, bool? order)
        {
            var booksList = _bookRepository.ReadBookList();
            return OrderBooks(booksList.Where(book => book.Specifications.Author?.ToLower().Contains(author?.ToLower()) == true).ToList(), order);
        }

        public List<Book> GetByGenre(string genre, bool? order)
        {
            var booksList = _bookRepository.ReadBookList();
            var booksByGenre = CompareGenre(genre, booksList);
            return OrderBooks(booksByGenre, order);
        }

        private List<Book> CompareGenre(string genre, List<Book> booksList)
        {
            var books = new List<Book>();
            foreach (var book in booksList)
            {
                if (book.Specifications.Genres is JArray genres)
                {
                    if (genres.Any(x => x.ToString() == genre))
                    {
                        books.Add(book);
                    }
                }
                else if (book.Specifications.Genres?.ToString() == genre)
                {
                    books.Add(book);
                }
            }

            return books;
        }

        public List<Book> GetByPrice(double price, bool? order)
        {
            var booksList = _bookRepository.ReadBookList();
            return OrderBooks(booksList.Where(book => book.Price == price).ToList(), order);
        }

        public List<Book> GetByPageCount(int pageCount, bool? order)
        {
            var booksList = _bookRepository.ReadBookList();
            return OrderBooks(booksList.Where(book => book.Specifications.Pagecount == pageCount).ToList(), order);
        }

        public List<Book> GetByIllustrator(string illustrator, bool? order)
        {
            var booksList = _bookRepository.ReadBookList();
            var bookByIllustrator = CompareIllustrator(illustrator, booksList);
            return OrderBooks(bookByIllustrator, order);
        }

        private List<Book> CompareIllustrator(string illustrator, List<Book> booksList)
        {
            var books = new List<Book>();
            foreach (var book in booksList)
            {
                if (book.Specifications.Illustrator is JArray illustrators)
                {
                    if (illustrators.Any(x => x.ToString() == illustrator))
                    {
                        books.Add(book);
                    }
                }
                else if (book.Specifications.Illustrator?.ToString() == illustrator)
                {
                    books.Add(book);
                }
            }

            return books;
        }

        public List<Book> GetByDate(string date, bool? order)
        {
            var booksList = _bookRepository.ReadBookList();
            return OrderBooks(booksList.Where(book => book.Specifications.Originallypublished == date).ToList(), order);
        }

        public double CalculateShipping(string bookName)
        {
            var books = GetByName(bookName);
            double shipping = books.Sum(book => book.Price) * 0.2;
            return Math.Round(shipping, 2);
        }
    }
}
