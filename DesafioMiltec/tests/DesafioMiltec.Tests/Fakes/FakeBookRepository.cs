using DesafioMiltec.Domain.Entities;
using DesafioMiltec.Domain.Interfaces;

namespace DesafioMiltec.Tests.Fakes
{
    internal sealed class FakeBookRepository : IBookRepository
    {
        private readonly IReadOnlyCollection<Book> _books;

        public FakeBookRepository(IReadOnlyCollection<Book> books)
        {
            _books = books;
        }

        public IReadOnlyCollection<Book> GetAll() => _books;

    }
}
