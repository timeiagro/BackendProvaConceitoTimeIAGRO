using Microsoft.AspNetCore.Mvc;
using Hamurabi.Core.Interfaces;
using Hamurabi.Core.Models;

namespace Hamurabi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/books
        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        // GET: api/books/search?term=Jules
        [HttpGet("search")]
        public ActionResult<List<Book>> SearchBooks([FromQuery] string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return BadRequest("O termo de busca não pode ser vazio.");
            }

            var books = _bookService.SearchBooks(term);
            return Ok(books);
        }

        // GET: api/books/ordered?ascending=true
        [HttpGet("ordered")]
        public ActionResult<List<Book>> GetBooksOrdered([FromQuery] bool ascending = true)
        {
            var books = _bookService.GetAllBooks();
            var orderedBooks = _bookService.OrderByPrice(books, ascending);
            return Ok(orderedBooks);
        }

        // GET: api/books/5/shipping
        [HttpGet("{id}/shipping")]
        public ActionResult<object> GetShipping(int id)
        {
            var books = _bookService.GetAllBooks();
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound($"Livro com ID {id} não encontrado.");
            }

            var result = new
            {
                bookId = book.Id,
                bookName = book.Name,
                price = book.Price,
                shipping = book.CalculateShipping(),
                totalPrice = book.GetTotalPrice()
            };

            return Ok(result);
        }
    }
}