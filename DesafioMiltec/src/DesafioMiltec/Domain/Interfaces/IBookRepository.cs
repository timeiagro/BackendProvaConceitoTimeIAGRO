using DesafioMiltec.Domain.Entities;

namespace DesafioMiltec.Domain.Interfaces
{
    public interface IBookRepository
    {
        IReadOnlyCollection<Book> GetAll();
    }
}
