using BuscadorDeLivros.Models;

namespace BuscadorDeLivros.Repositories
{
    public interface IBooksRepository
    {
        public Task<List<Book>>? BuscarTodosAsync();
        public Task<Book>? BuscarPorIdAsync(int id);
    }
}
