using Arbooks.Business.Repository;
using Arbooks.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Arbooks.API.Controllers
{
    [ApiController]
    [Route("book")]
    public class BookController : ControllerBase
    {
        BookService _bookServices;

        public BookController()
        {
            this._bookServices = new BookService(new BookRepository());
        }

        [HttpGet("search")]
        public IActionResult Search(string? term, string? order)
        {
            var bookList = _bookServices.Search(term, order);
            return Ok(bookList);
        }

        [HttpGet("details")]
        public IActionResult Details(int id)
        {
            var book = _bookServices.Details(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet("calculateshipping")]
        public IActionResult CalculateShipping(int id)
        {
            var book = _bookServices.Details(id);

            if (book == null)
                return NotFound();

            var shippingService = new ShippingService();
            var shippingValue = shippingService.Calculate(book.price);

            return Ok(shippingValue);
        }
    }
}
