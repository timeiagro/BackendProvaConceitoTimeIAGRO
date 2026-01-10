using DesafioMiltec.Application.Mappers;
using DesafioMiltec.Application.Services;
using DesafioMiltec.Application.Sorting;
using DesafioMiltec.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace DesafioMiltec.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Busca livros por nome, autor ou qualquer especificação.
        /// </summary>
        /// <param name="search">Texto para busca</param>
        /// <param name="order">Ordenação por preço: asc ou desc</param>
        /// <returns>Lista de livros</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(
                [FromQuery] string? search,
                [FromServices] PriceSortAsc priceSortAsc,
                [FromServices] PriceSortDesc priceSortDesc,
                [FromQuery] string order = "asc")
        {
            IBookSort sortStrategy = order.Equals("desc", StringComparison.OrdinalIgnoreCase)
                ? priceSortDesc
                : priceSortAsc;

            var books = _bookService.Search(search, sortStrategy);

            var result = books
               .Select(BookMapper.ToDto)
               .ToList();

            return Ok(result);

        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookDto> GetById(long id)
        {
            if (id <= 0)
                return BadRequest("O id deve ser maior que zero.");

            var book = _bookService.GetById(id);

            if (book is null)
                return NotFound($"Livro com id {id} não encontrado.");

            return Ok(BookMapper.ToDto(book));
        }

        /// <summary>
        /// Calcula o valor do frete (20%) para um livro específico.
        /// </summary>
        /// <param name="id">Id do livro</param>
        /// <returns>Valor do frete</returns>
        [HttpGet("{id:long}/calcularfrete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetFreight(long id)
        {
            var book = _bookService.GetById(id);

            if (book is null)
                return NotFound($"Livro com id {id} não encontrado.");

            var freight = _bookService.CalculateShipping(book.Price);

            var culture = new CultureInfo("pt-BR");

            var dto = new ShippingDto
            {
                BookId = book.Id,
                BookName = book.Name,
                BookPrice = book.Price.ToString("C", culture),
                Freight = freight.ToString("C", culture)
            };

            return Ok(dto);
        }
    }
}
