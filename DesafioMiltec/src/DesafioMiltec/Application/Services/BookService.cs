using DesafioMiltec.Application.Sorting;
using DesafioMiltec.Domain.Entities;
using DesafioMiltec.Domain.Interfaces;
using System.Text.Json;


namespace DesafioMiltec.Application.Services
{
    public sealed class BookService
    {
        private readonly IBookRepository _repository;
        private readonly ICalculateShipping _shippingCalculator;

        public BookService(
            IBookRepository repository,
            ICalculateShipping shippingCalculator)
        {
            _repository = repository;
            _shippingCalculator = shippingCalculator;
        }

        public IReadOnlyCollection<Book> Search(
            string? term,
            IBookSort sort)
        {
            var books = _repository.GetAll().AsEnumerable();

            if (!string.IsNullOrWhiteSpace(term))
            {
                books = books.Where(book =>
                book.Name.Contains(term, StringComparison.OrdinalIgnoreCase)
                || book.Specifications.Any(x =>
                    JsonElementContains(x.Value, term)));
            }

            return sort.Sort(books).ToList();
        }

        public Book? GetById(long id)
        {
            if (id <= 0)
                return null;

            return _repository
                .GetAll()
                .FirstOrDefault(b => b.Id == id);
        }

        public decimal CalculateShipping(decimal price)
            => _shippingCalculator.Calculate(price);

        private static bool JsonElementContains(JsonElement element, string term)
        {
            return element.ValueKind switch
            {
                JsonValueKind.String =>
                    element.GetString()?
                        .Contains(term, StringComparison.OrdinalIgnoreCase) == true,

                JsonValueKind.Number =>
                    element.ToString()
                        .Contains(term, StringComparison.OrdinalIgnoreCase),

                JsonValueKind.Array =>
                    element.EnumerateArray()
                           .Any(e => JsonElementContains(e, term)),

                _ => false
            };
        }

    }
}
