using DesafioMiltec.Domain.Entities;

namespace DesafioMiltec.Application.Sorting
{
    public sealed class PriceSortAsc : IBookSort
    {
        public IEnumerable<Book> Sort(IEnumerable<Book> books)
           => books.OrderBy(b => b.Price);
    }
}
