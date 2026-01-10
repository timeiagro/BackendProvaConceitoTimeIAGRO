using DesafioMiltec.Domain.Entities;

namespace DesafioMiltec.Application.Sorting
{
    public interface IBookSort
    {
        IEnumerable<Book> Sort(IEnumerable<Book> books);
    }
}
