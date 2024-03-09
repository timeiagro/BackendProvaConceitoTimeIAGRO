using WebLivro.Enum;
using WebLivros.Models;

namespace WebLivros.Interfaces;

public interface IBookModelService
{
    List<BookModel> GetBookModels(AscDescEnum ordem);
    List<BookModel> GetByIllustrator(string illustrator);
    List<BookModel> GetByName(string name);
    List<BookModel> GetByAuthor(string author);
    List<BookModel> GetByGenres(string genres);
    double GetValueFrete(int id);
}