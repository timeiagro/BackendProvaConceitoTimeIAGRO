using WebLivro.Enum;
using WebLivro.repository;
using WebLivros.Models;
using WebLivros.Services;

namespace WebLivroTest;

public class BookModelServiceTest
{
    BookModelService bookModelService;

    [SetUp]
    public void Setup()
    {
        bookModelService = new BookModelService(new BookModelRepository(new HttpClient()));
    }
    [Test]
    public void GetSize()
    { 
        List<BookModel> books = bookModelService.GetBookModels(AscDescEnum.Asc);
        Assert.AreEqual(5, books.Count);
    }
    
    [Test] 
    public void GetByAuthor()
    {
        List<BookModel> books  = bookModelService.GetByAuthor("Jules");
        Assert.IsNotNull(books);
        Assert.IsInstanceOf<List<BookModel>>(books);
        Assert.AreEqual(2, books.Count);
           
    }
    [Test]
    public void GetByIllustrator()
    {
        List<BookModel> books  = bookModelService.GetByIllustrator("Riou");
        Assert.IsNotNull(books);
        Assert.AreEqual(2, books.Count);

    }
    
    [Test]
    public void GetByGenres()
    {
        List<BookModel> books  = bookModelService.GetByGenres("Fiction");
        Assert.IsNotNull(books);
        Assert.AreEqual(5, books.Count);

    }
    [Test]
    public void GetByName()
    {
        List<BookModel> result = bookModelService.GetByName("Lord");
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
    }
}