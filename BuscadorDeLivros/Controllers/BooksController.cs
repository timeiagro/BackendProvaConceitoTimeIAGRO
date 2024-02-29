using BuscadorDeLivros.Models;
using BuscadorDeLivros.Repositories;
using BuscadorDeLivros.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuscadorDeLivros.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IFreteService _freteService;

        public BooksController(IBookRepository bookRepository, IFreteService freteService)
        {
            _bookRepository = bookRepository;
            _freteService = freteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>>? Get(
            [FromQuery] string? nome,
            [FromQuery] decimal? preco,
            [FromQuery] string? genero,
            [FromQuery] string? orderByPrice)
        {
            try
            {
                var books = _bookRepository.BuscarTodos();
                if (books is null) return Ok(new List<Book>());

                if (!string.IsNullOrWhiteSpace(nome))
                    books = books.Where(b => b.Name.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();

                if (preco.HasValue)
                    books = books.Where(b => b.Price == preco.Value).ToList();

                if (!string.IsNullOrWhiteSpace(genero))
                    books = books.Where(b =>
                        (b.Specifications.Genres is string &&
                            b.Specifications.Genres.Contains(genero, StringComparison.OrdinalIgnoreCase)) ||
                        (b.Specifications.Genres is IEnumerable<string> arr &&
                            arr.Any(g => g.Contains(genero, StringComparison.Ordinal)))
                    ).ToList();

                if (!string.IsNullOrWhiteSpace(orderByPrice))
                {
                    if (orderByPrice == "asc")
                        books = books.OrderBy(b => b.Price).ToList();
                    else if (orderByPrice == "desc")
                        books = books.OrderByDescending(b => b.Price).ToList();
                    else
                        return BadRequest("OrderByPrice deve receber apenas os parâmetros \"asc\" ou \"desc\" ");
                }

                return Ok(books);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro no sistema.");
            }
        }

        [HttpGet("Frete/{bookId}")]
        public ActionResult<Book> CalcularFrete(int bookId)
        {
            try
            {
                var book = _bookRepository.BuscarPorId(bookId);
                if (book == null) return NotFound("Livro não encontrado.");

                var valorDoFrete = _freteService.CalcularFrete(book.Price);
                return Ok(new { 
                    bookId = book.Id, 
                    bookPrice = book.Price, 
                    bookShipping = valorDoFrete.ToString("c") 
                });
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro no sistema.");
            }
        }
    }
}
