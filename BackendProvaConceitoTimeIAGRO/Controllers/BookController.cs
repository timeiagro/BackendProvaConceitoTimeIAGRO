using BackendProvaConceitoTimeIAGRO.Enums;
using BackendProvaConceitoTimeIAGRO.Models;
using BackendProvaConceitoTimeIAGRO.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackendProvaConceitoTimeIAGRO.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController: ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetBooks")]
        public async Task<ActionResult<ServiceReponse<BookModel>>> GetBooks([FromQuery] AscDescEnum ordem)
        {
            return Ok(await _bookService.GetBooks(ordem));
        }
        [HttpGet("search-by-author")]
        public async Task<ActionResult<ServiceReponse<BookModel>>> GetByAuthor([FromQuery] AscDescEnum ordem, string author)
        {
            return Ok(await _bookService.GetByAuthor(ordem, author.ToLower().Trim()));
        }
        [HttpGet("search-by-name")]
        public async Task<ActionResult<ServiceReponse<BookModel>>> GetByName([FromQuery] AscDescEnum ordem, string name)
        {
            return Ok(await _bookService.GetByName(ordem, name.ToLower().Trim()));
        }
        [HttpGet("search-by-price")]
        public async Task<ActionResult<ServiceReponse<BookModel>>> GetByPrice([FromQuery] AscDescEnum ordem, double price)
        {
            return Ok(await _bookService.GetByPrice(ordem, price));
        }
        [HttpGet("search-by-published")]
        public async Task<ActionResult<ServiceReponse<BookModel>>> GetByPublished([FromQuery] AscDescEnum ordem, string published)
        {
            return Ok(await _bookService.GetByPublished(ordem, published));
        }
        [HttpGet("search-by-Illustrator")]
        public async Task<ActionResult<ServiceReponse<BookModel>>> GetByIllustrator([FromQuery] AscDescEnum ordem, string illustrator)
        {
            return Ok(await _bookService.GetByIllustrator(ordem, illustrator.Trim()));
        }
        [HttpGet("search-by-Genres")]
        public async Task<ActionResult<ServiceReponse<BookModel>>> GetByGenres([FromQuery] AscDescEnum ordem, string genres)
        {
            return Ok(await _bookService.GetByGenres(ordem, genres.Trim()));
        }
        [HttpGet("calculate-shipping")]
        public async Task<ActionResult<ServiceReponse<BookModel>>> CalculateShipping([FromQuery] AscDescEnum ordem, string name)
        {
            return Ok(await _bookService.CalculateShipping(ordem, name.ToLower().Trim()));
        }
    }
}
