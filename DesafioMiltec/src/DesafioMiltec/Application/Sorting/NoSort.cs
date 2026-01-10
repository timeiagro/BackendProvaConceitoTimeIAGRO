using DesafioMiltec.Domain.Entities;

namespace DesafioMiltec.Application.Sorting
{
    public sealed class NoSort : IBookSort
    {
        public IEnumerable<Book> Sort(IEnumerable<Book> books)
            => books;
    }
}
