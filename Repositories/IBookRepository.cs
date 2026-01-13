using CatalogoLivros.Api.Models;

namespace CatalogoLivros.Api.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book? GetById(long id);
    }
}
