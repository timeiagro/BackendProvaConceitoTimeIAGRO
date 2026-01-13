using Hamurabi.Core.Interfaces;
using Hamurabi.Core.Models;
using Hamurabi.Core.Services;
using Moq;

namespace Hamurabi.Tests
{
    public class BookServiceTests
    {
        private readonly Mock<IBookRepository> _mockRepository;
        private readonly IBookService _bookService;
        private readonly List<Book> _sampleBooks;

        public BookServiceTests()
        {
            _mockRepository = new Mock<IBookRepository>();
            _bookService = new BookService(_mockRepository.Object);

            // Dados de exemplo para testes
            _sampleBooks = new List<Book>
            {
                new Book { Id = 1, Name = "Journey to the Center of the Earth", Price = 10.00m, 
                    Specifications = new BookSpecifications { Author = "Jules Verne" } },
                new Book { Id = 2, Name = "Harry Potter", Price = 7.31m, 
                    Specifications = new BookSpecifications { Author = "J. K. Rowling" } },
                new Book { Id = 3, Name = "The Lord of the Rings", Price = 6.15m, 
                    Specifications = new BookSpecifications { Author = "J. R. R. Tolkien" } }
            };
        }

        [Fact]
        public void GetAllBooks_ShouldReturnAllBooks()
        {
            // Arrange
            _mockRepository.Setup(r => r.GetAllBooks()).Returns(_sampleBooks);

            // Act
            var result = _bookService.GetAllBooks();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void SearchBooks_ShouldReturnBooksMatchingAuthor()
        {
            // Arrange
            _mockRepository.Setup(r => r.GetAllBooks()).Returns(_sampleBooks);

            // Act
            var result = _bookService.SearchBooks("Jules");

            // Assert
            Assert.Single(result);
            Assert.Equal("Journey to the Center of the Earth", result[0].Name);
        }

        [Fact]
        public void OrderByPrice_Ascending_ShouldReturnBooksInAscendingOrder()
        {
            // Arrange
            var books = _sampleBooks;

            // Act
            var result = _bookService.OrderByPrice(books, ascending: true);

            // Assert
            Assert.Equal(6.15m, result[0].Price);
            Assert.Equal(10.00m, result[2].Price);
        }

        [Fact]
        public void OrderByPrice_Descending_ShouldReturnBooksInDescendingOrder()
        {
            // Arrange
            var books = _sampleBooks;

            // Act
            var result = _bookService.OrderByPrice(books, ascending: false);

            // Assert
            Assert.Equal(10.00m, result[0].Price);
            Assert.Equal(6.15m, result[2].Price);
        }

        [Fact]
        public void Book_CalculateShipping_ShouldReturn20Percent()
        {
            // Arrange
            var book = new Book { Price = 10.00m };

            // Act
            var shipping = book.CalculateShipping();

            // Assert
            Assert.Equal(2.00m, shipping);
        }
    }
}