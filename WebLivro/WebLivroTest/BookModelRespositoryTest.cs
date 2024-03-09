using WebLivro.repository;
using WebLivros.Models;

namespace WebLivroTest;

public class BookModelRespositoryTest
{
    BookModelRepository bookModelRespository;

    [SetUp]
    public void Setup()
    {
        bookModelRespository = new BookModelRepository(new HttpClient());
    }
    [Test]
    public void GetSize()
    { 
        List<BookModel> books = bookModelRespository.GetBookModels();
        Assert.AreEqual(5, books.Count);
    }
    
    [Test]
    public void GetServiceReponseBooks()
    { 
        Task<ServiceReponse<BookModel>> books = bookModelRespository.GetServiceReponseBooks();
        Assert.IsInstanceOf<ServiceReponse<BookModel>>(books.Result);
        Assert.IsInstanceOf<List<BookModel>>(books.Result.Dados);
        Assert.AreEqual(5, books.Result.Dados.Count);
    }
    
    [Test] 
    public void GetByAuthor()
    {
        List<BookModel> books  = bookModelRespository.GetByAuthor("Jules");
        Assert.IsNotNull(books);
        Assert.IsInstanceOf<List<BookModel>>(books);
        Assert.AreEqual(2, books.Count);
           
    }
    [Test]
    public void GetByIllustrator()
    {
        List<BookModel> books  = bookModelRespository.GetByIllustrator("Riou");
        Assert.IsNotNull(books);
        Assert.AreEqual(2, books.Count);

    }
    
    [Test]
    public void GetByGenres()
    {
        List<BookModel> books  = bookModelRespository.GetByGenres("Fiction");
        Assert.IsNotNull(books);
        Assert.AreEqual(5, books.Count);

    }
    [Test]
    public void GetByName()
    {
        List<BookModel> result = bookModelRespository.GetByName("Lord");
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
    }
}