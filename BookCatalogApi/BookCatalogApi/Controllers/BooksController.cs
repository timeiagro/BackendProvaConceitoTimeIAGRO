using BookCatalogApi.Dtos;
using BookCatalogApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BookResponse>> Search(
        [FromQuery] string? name,
        [FromQuery] string? author,
        [FromQuery] string? genre,
        [FromQuery] string? illustrator,
        [FromQuery] string? query,
        [FromQuery] string? sortBy,
        [FromQuery] string? sortOrder)
    {
        var request = new BookSearchRequest
        {
            Name = name,
            Author = author,
            Genre = genre,
            Illustrator = illustrator,
            Query = query,
            SortBy = sortBy,
            SortOrder = sortOrder
        };

        var books = _bookService.Search(request);

        return Ok(books);
    }

    [HttpGet("{id:int}")]
    public ActionResult<BookResponse> GetById(int id)
    {
        var book = _bookService.GetById(id);

        if (book is null)
            return NotFound("Book not found.");

        return Ok(book);
    }

    [HttpGet("{id:int}/shipping")]
    public ActionResult<object> GetShippingCost(int id)
    {
        try
        {
            var shippingCost = _bookService.CalculateShipping(id);
            var book = _bookService.GetById(id);

            return Ok(new
            {
                bookId = id,
                bookName = book?.Name,
                bookPrice = book?.Price,
                shippingCost,
                shippingPercentage = "20%",
                totalPrice = book?.Price + shippingCost
            });
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Book not found.");
        }
    }
}
