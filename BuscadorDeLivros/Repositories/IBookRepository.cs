using BuscadorDeLivros.Models;

namespace BuscadorDeLivros.Repositories
{
    public interface IBookRepository
    {
        public List<Book>? BuscarTodos();
        public Book BuscarPorId(int id);
    }
}
