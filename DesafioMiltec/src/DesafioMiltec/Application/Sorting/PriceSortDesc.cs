using DesafioMiltec.Domain.Entities;

namespace DesafioMiltec.Application.Sorting
{
    public sealed class PriceSortDesc : IBookSort
    {
        public IEnumerable<Book> Sort(IEnumerable<Book> books)
           => books.OrderByDescending(b => b.Price);
    }    
}
