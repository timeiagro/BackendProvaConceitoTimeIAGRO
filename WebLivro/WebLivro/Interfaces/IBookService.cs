using WebLivros.Models;

namespace WebLivros.Interfaces
{
    public interface IBookService
    {
        List<Book> GetBooks();
        List<Book> GetByName(string name);
        List<Book> GetByAuthor(string name);
        List<Book> GetByAsc();
        List<Book> GetByDesc();
        double GetValueFrete(int id);
        List<Book> GetByGenres(string parametros);
        List<Book> GetByIllustrator(string parametros);
    }

}
