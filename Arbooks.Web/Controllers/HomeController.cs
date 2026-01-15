using Arbooks.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Arbooks.Web.Controllers
{
    public class HomeController : Controller
    {
        HttpClient _httpClient;

        public HomeController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> Index(string search, string order)
        {
            var response = await _httpClient.GetAsync("http://localhost:5013/book/search?term=" + search + "&order=" + order);
            var jsonString = await response.Content.ReadAsStringAsync();
            var bookList = JsonSerializer.Deserialize<List<BookDTO>>(jsonString);

            ViewData["bookList"] = bookList;
            ViewData["search"] = search;
            ViewData["order"] = order;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BookDetails(int id)
        {
            var response = await _httpClient.GetAsync("http://localhost:5013/book/details?id=" + id);
            var jsonString = await response.Content.ReadAsStringAsync();
            var book = JsonSerializer.Deserialize<BookDTO>(jsonString);

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> CalculateShipping(int id)
        {
            var response = await _httpClient.GetAsync("http://localhost:5013/book/details?id=" + id);
            var jsonString = await response.Content.ReadAsStringAsync();
            var book = JsonSerializer.Deserialize<BookDTO>(jsonString);

            if (book == null)
                return NotFound();

            response = await _httpClient.GetAsync("http://localhost:5013/book/calculateshipping?id=" + id);
            jsonString = await response.Content.ReadAsStringAsync();
            var shippingValue = JsonSerializer.Deserialize<decimal>(jsonString);

            ViewData["ShippingValue"] = shippingValue;

            return View("BookDetails", book);
        }
    }
}
