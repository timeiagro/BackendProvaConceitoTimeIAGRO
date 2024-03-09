using WebLivros.Models;
using WebLivros.Services;

namespace WebLivroTest
{
    [TestFixture]
    public class BookServiceTest
    {
        BookService bookService;

        [SetUp]
        public void Setup()
        {
            bookService = new BookService();
        }

        [Test]
        public void GetSize()
        {
            List<Book> books = bookService.GetBooks();
            Assert.AreEqual(5, books.Count);
        }

        [Test]
        public void GetByAsc()
        {
            List<Book> books = bookService.GetByAsc();
            Assert.AreEqual(5, books.Count);
            Assert.AreEqual(6.15, books[0].price);
            Assert.AreEqual(5, books[0].Id);
            Assert.AreEqual(7.31, books[1].price);
            Assert.AreEqual(3, books[1].Id);
            Assert.AreEqual(10, books[2].price);
            Assert.AreEqual(1, books[2].Id);
            Assert.AreEqual(10.1, books[3].price);
            Assert.AreEqual(2, books[3].Id);
            Assert.AreEqual(11.15, books[4].price);
            Assert.AreEqual(4, books[4].Id);
        }

        [Test]
        public void GetByDesc()
        {
            List<Book> books = bookService.GetByDesc();

            Assert.AreEqual(5, books.Count);


            Assert.AreEqual(11.15, books[0].price);
            Assert.AreEqual(4, books[0].Id);

            Assert.AreEqual(10.1, books[1].price);
            Assert.AreEqual(2, books[1].Id);

            Assert.AreEqual(10, books[2].price);
            Assert.AreEqual(1, books[2].Id);

            Assert.AreEqual(7.31, books[3].price);
            Assert.AreEqual(3, books[3].Id);


            Assert.AreEqual(6.15, books[4].price);
            Assert.AreEqual(5, books[4].Id);
        }

        [Test]
        public void GetValueFrete()
        {
            Assert.AreEqual(12, bookService.GetValueFrete(1));

            Assert.AreEqual(12.12, bookService.GetValueFrete(2));

            Assert.AreEqual(8.77, bookService.GetValueFrete(3));

            Assert.AreEqual(13.38, bookService.GetValueFrete(4));

            Assert.AreEqual(7.38, bookService.GetValueFrete(5));
        }

        [Test]
        public void GetByAuthor()
        {
            List<Book> result = bookService.GetByAuthor("Jules");
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetByName()
        {
            List<Book> result = bookService.GetByName("Lord");
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetByNameNotFound()
        {
            List<Book> result = bookService.GetByName("crepusculo");
            Assert.IsEmpty(result);
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void GetByIllustrator()
        {
            List<Book> result = bookService.GetByIllustrator("Riou");
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetByGenres()
        {
            List<Book> result = bookService.GetByGenres("Fiction");
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count);
        }

        [Test]
        public void GetByGenre()
        {
            List<Book> result = bookService.GetByGenres("Science");
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }
    }
}