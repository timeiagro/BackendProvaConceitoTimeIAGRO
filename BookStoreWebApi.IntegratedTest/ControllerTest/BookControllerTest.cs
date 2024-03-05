using AutoFixture;
using BookStoreWebApi.Controllers;
using BookStoreWebApi.Interfaces;
using BookStoreWebApi.Models.Entities;
using Newtonsoft.Json;
using NSubstitute;
using Xunit;

namespace BookStoreWebApi.IntegratedTest.ControllerTest
{
    public class BookControllerTest : BaseControllerTest<BookController>
    {
        private readonly BookController _bookController;
        private readonly IBookService _bookService;

        public BookControllerTest()
        {
            _bookService = Substitute.For<IBookService>();
            _bookController = new BookController(_bookService);
        }


        [Fact]
        public void GetByNameTest()
        {
            // Arrange
            var name = _fixture.Create<string>();
            var order = _fixture.Create<bool>();
            var expectedResult = _fixture.Create<List<Book>>();

            _bookService.GetByName(name).Returns(expectedResult);

            // Act
            var result = _bookController.GetByName(name, order);

            // Assert
            var expectedJsonResult = JsonConvert.SerializeObject(expectedResult);
            Assert.Equal(expectedJsonResult, result);
        }

        [Fact]
        public void ListBooksTest()
        {
            // Arrange
            var order = _fixture.Create<bool>();
            var expectedResult = _fixture.Create<List<Book>>();

            _bookService.ListBooks(order).Returns(expectedResult);

            // Act
            var result = _bookController.ListBooks(order);

            // Assert
            var expectedJsonResult = JsonConvert.SerializeObject(expectedResult);
            Assert.Equal(expectedJsonResult, result);
        }

        [Fact]
        public void GetByAuthorTest()
        {
            // Arrange
            var author = _fixture.Create<string>();
            var order = _fixture.Create<bool>();
            var expectedResult = _fixture.Create<List<Book>>();

            _bookService.GetByAuthor(author, order).Returns(expectedResult);

            // Act
            var result = _bookController.GetByAuthor(author, order);

            // Assert
            var expectedJsonResult = JsonConvert.SerializeObject(expectedResult);
            Assert.Equal(expectedJsonResult, result);
        }

        [Fact]
        public void GetByGenreTest()
        {
            // Arrange
            var genre = _fixture.Create<string>();
            var order = _fixture.Create<bool>();
            var expectedResult = _fixture.Create<List<Book>>();

            _bookService.GetByGenre(genre, order).Returns(expectedResult);

            // Act
            var result = _bookController.GetByGenre(genre, order);

            // Assert
            var expectedJsonResult = JsonConvert.SerializeObject(expectedResult);
            Assert.Equal(expectedJsonResult, result);
        }

        [Fact]
        public void GetByPriceTest()
        {
            // Arrange
            var price = _fixture.Create<double>();
            var order = _fixture.Create<bool>();
            var expectedResult = _fixture.Create<List<Book>>();

            _bookService.GetByPrice(price, order).Returns(expectedResult);

            // Act
            var result = _bookController.GetByPrice(price, order);

            // Assert
            var expectedJsonResult = JsonConvert.SerializeObject(expectedResult);
            Assert.Equal(expectedJsonResult, result);
        }

        [Fact]
        public void GetByPageCountTest()
        {
            // Arrange
            var pageCount = _fixture.Create<int>();
            var order = _fixture.Create<bool>();
            var expectedResult = _fixture.Create<List<Book>>();

            _bookService.GetByPageCount(pageCount, order).Returns(expectedResult);

            // Act
            var result = _bookController.GetByPageCount(pageCount, order);

            // Assert
            var expectedJsonResult = JsonConvert.SerializeObject(expectedResult);
            Assert.Equal(expectedJsonResult, result);
        }

        [Fact]
        public void GetByIllustratorTest()
        {
            // Arrange
            var illustrator = _fixture.Create<string>();
            var order = _fixture.Create<bool>();
            var expectedResult = _fixture.Create<List<Book>>();

            _bookService.GetByIllustrator(illustrator, order).Returns(expectedResult);

            // Act
            var result = _bookController.GetByIllustrator(illustrator, order);

            // Assert
            var expectedJsonResult = JsonConvert.SerializeObject(expectedResult);
            Assert.Equal(expectedJsonResult, result);
        }

        [Fact]
        public void GetByDateTest()
        {
            // Arrange
            var date = _fixture.Create<string>();
            var order = _fixture.Create<bool>();
            var expectedResult = _fixture.Create<List<Book>>();

            _bookService.GetByDate(date, order).Returns(expectedResult);

            // Act
            var result = _bookController.GetByDate(date, order);

            // Assert
            var expectedJsonResult = JsonConvert.SerializeObject(expectedResult);
            Assert.Equal(expectedJsonResult, result);
        }
    }
}
