using AutoFixture;
using BookStoreWebApi.Interfaces;
using BookStoreWebApi.Models.Entities;
using BookStoreWebApi.Services;
using NSubstitute;
using Xunit;

namespace BookStoreWebApi.IntegratedTest.ServiceTest
{
    public class BookServiceTest : BaseServiceTest
    {
        private readonly IBookService _bookService;
        private readonly IReadJson _readJson;

        public BookServiceTest()
        {
            _readJson = Substitute.For<IReadJson>();
            _bookService = new BookService(_readJson);
        }

        [Fact]
        public void GetByNameTest()
        {
            // Arrange
            var name = _fixture.Create<string>();
            var expectedResult = _fixture.CreateMany<Book>().ToList();

            _readJson.ReadBookList().Returns(expectedResult);

            // Act
            var result = _bookService.GetByName(name);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void ListBooksTest()
        {
            // Arrange
            var order = _fixture.Create<bool>();
            var expectedResult = _fixture.CreateMany<Book>().ToList();

            _readJson.ReadBookList().Returns(expectedResult);

            // Act
            var result = _bookService.ListBooks(order);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetByAuthorTest()
        {
            // Arrange
            var author = _fixture.Create<string>();
            var order = _fixture.Create<bool>();
            var expectedResult = _fixture.CreateMany<Book>().ToList();

            _readJson.ReadBookList().Returns(expectedResult);

            // Act
            var result = _bookService.GetByAuthor(author, order);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetByGenreTest()
        {
            // Arrange
            var genre = _fixture.Create<string>();
            var order = _fixture.Create<bool>();
            var expectedResult = _fixture.CreateMany<Book>().ToList();

            _readJson.ReadBookList().Returns(expectedResult);

            // Act
            var result = _bookService.GetByGenre(genre, order);

            // Assert
            Assert.NotNull( result);
        }

        [Fact]
        public void GetByPriceTest()
        {
            // Arrange
            var price = _fixture.Create<double>();
            var order = _fixture.Create<bool>();
            var expectedResult = _fixture.CreateMany<Book>().ToList();

            _readJson.ReadBookList().Returns(expectedResult);

            // Act
            var result = _bookService.GetByPrice(price, order);

            // Assert
             Assert.NotNull(result);
        }

        [Fact]
        public void GetByPageCountTest()
        {
            // Arrange
            var pageCount = _fixture.Create<int>();
            var order = _fixture.Create<bool>();
            var expectedResult = _fixture.CreateMany<Book>().ToList();

            _readJson.ReadBookList().Returns(expectedResult);

            // Act
            var result = _bookService.GetByPageCount(pageCount, order);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetByIllustratorTest()
        {
            // Arrange
            var illustrator = _fixture.Create<string>();
            var order = _fixture.Create<bool>();
            var expectedResult = _fixture.CreateMany<Book>().ToList();

            _readJson.ReadBookList().Returns(expectedResult);

            // Act
            var result = _bookService.GetByIllustrator(illustrator, order);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetByDateTest()
        {
            // Arrange
            var date = _fixture.Create<string>();
            var order = _fixture.Create<bool>();
            var expectedResult = _fixture.CreateMany<Book>().ToList();

            _readJson.ReadBookList().Returns(expectedResult);

            // Act
            var result = _bookService.GetByDate(date, order);

            // Assert
            Assert.NotNull(result);
        }

        public class MockIllustrator
        {
            public static List<string> GetMockIllustrator()
            {
                return new List<string> { "John Doe", "Jane Doe", "Illustrator3" };
            }
        }

        public class MockGenres
        {
            public static List<string> GetMockGenres()
            {
                return new List<string> { "Fiction", "Mystery", "Genres3" };
            }
        }
    }
}
