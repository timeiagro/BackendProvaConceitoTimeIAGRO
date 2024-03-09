using Moq;
using WebLivros.Interfaces;
using NUnit.Framework;
using WebLivro.Controllers;
using WebLivros.Models;

namespace WebLivroTest;
[TestFixture]
public class BookControllerTest
{
    
    private Mock<IBookService> _mockBookService;
    private BookController bookController;
    
    [SetUp]
    public void Setup()
    {
        _mockBookService = new Mock<IBookService>();
        bookController = new BookController(_mockBookService.Object);
    }

    [Test]
    public void GetBooks()
    {
        var books = new List<Book>();

        _mockBookService.Setup(x => x.GetBooks()).Returns(books);
        var result = bookController.Get();
        
        Assert.AreEqual(books, result);
        _mockBookService
            .Verify(x => x.GetBooks(), Times.Once);
    }
    [Test]
    public void GetByAuthor()
    {
        var books = new List<Book>();

        _mockBookService.Setup(x => x.GetByAuthor("Jules")).Returns(books);
        var result = bookController.GetByAuthor("Jules");
        
        Assert.AreEqual(books, result);
        _mockBookService
            .Verify(x => x.GetByAuthor("Jules"), Times.Once);
    }
    
    
}