using WebLivros.Models;

namespace WebLivro.repository;

public interface IBookModelRepository
{
    List<BookModel> GetBookModels();
    List<BookModel> GetByIllustrator(string illustrator);
    List<BookModel> GetByName(string name);
    List<BookModel> GetByAuthor(string author);
    List<BookModel> GetByGenres(string genres);
    BookModel GetById(int id);
}