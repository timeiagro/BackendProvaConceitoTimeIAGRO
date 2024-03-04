using BuscadorDeLivros.Models;

namespace BuscadorDeLivros.Repositories
{
    public interface IBooksRepository
    {
        public List<Book>? BuscarTodos();
        public Book? BuscarPorId(int id);
    }
}
