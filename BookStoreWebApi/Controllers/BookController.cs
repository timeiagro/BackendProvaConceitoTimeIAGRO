using BookStoreWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStoreWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("GetBooks")]
        public string GetByName(string name, bool? order)
        {
            var result = _bookService.GetByName(name);
            return JsonConvert.SerializeObject(result);
        }

        [HttpGet]
        [Route("GetListBooks")]
        public string ListBooks(bool? order)
        {
            var result = _bookService.ListBooks(order);
            return JsonConvert.SerializeObject(result);
        }

        [HttpGet]
        [Route("GetBooksByAuthor")]
        public string GetByAuthor(string author, bool? order)
        {
            var result = _bookService.GetByAuthor(author, order);
            return JsonConvert.SerializeObject(result);
        }

        [HttpGet]
        [Route("GetBooksByGenre")]
        public string GetByGenre(string genre, bool? order)
        {
            var result = _bookService.GetByGenre(genre, order);
            return JsonConvert.SerializeObject(result);
        }

        [HttpGet]
        [Route("GetBooksByPrice")]
        public string GetByPrice(double price, bool? order)
        {
            var result = _bookService.GetByPrice(price, order);
            return JsonConvert.SerializeObject(result);
        }

        [HttpGet]
        [Route("GetBooksByPageCount")]
        public string GetByPageCount(int pageCount, bool? order)
        {
            var result = _bookService.GetByPageCount(pageCount, order);
            return JsonConvert.SerializeObject(result);
        }

        [HttpGet]
        [Route("GetBooksByIllustrator")]
        public string GetByIllustrator(string illustrator, bool? order)
        {
            var result = _bookService.GetByIllustrator(illustrator, order);
            return JsonConvert.SerializeObject(result);
        }


        [HttpGet]
        [Route("GetBooksByDate")]
        public string GetByDate(string date, bool? order)
        {
            var result = _bookService.GetByDate(date, order);
            return JsonConvert.SerializeObject(result);
        }

        [HttpGet]
        [Route("CalculateShipping")]
        public string CalculateShipping(string bookName)
        {
            var result = _bookService.CalculateShipping(bookName);
            return JsonConvert.SerializeObject(result);
        }
    }
}
