using Microsoft.AspNetCore.Mvc;
using CatalogoLivros.Api.Services;

//é o start da API e chama o service
namespace CatalogoLivros.Api.Controllers
{
    [ApiController]
    [Route("books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Search(
            [FromQuery] string? title,
            [FromQuery] string? author,
            [FromQuery] string? sort)
        {
            return Ok(_service.Search(title, author, sort));
        }

            [HttpGet("{id}/freight")]
        public IActionResult CalculateFreight(long id)
        {
            var freight = _service.CalculateFreight(id);
            return Ok(freight);
        }
    }
}
