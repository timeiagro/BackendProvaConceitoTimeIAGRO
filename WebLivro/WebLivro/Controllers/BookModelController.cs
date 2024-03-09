using Microsoft.AspNetCore.Mvc;
using WebLivro.Enum;
using WebLivros.Interfaces;
using WebLivros.Models;

namespace WebLivro.Controllers;

[ApiController]
[Route("/BookModel")]
public class BookModelController : ControllerBase
{
    private IBookModelService bookModelService;

    public BookModelController(IBookModelService _bookModelService)
    {
        this.bookModelService = _bookModelService;
    }

    [HttpGet]
    public List<BookModel> Get([FromQuery] AscDescEnum ordem)
    {
        return bookModelService.GetBookModels(ordem);
    }


    [HttpGet("nome/{name}")]
    public List<BookModel> GetByName(string name)
    {
        return bookModelService.GetByName(name);
    }

    [HttpGet("illustrator/{name}")]
    public List<BookModel> GetByIllustrator(string name)
    {
        return bookModelService.GetByIllustrator(name);
    }

    [HttpGet("genere/{name}")]
    public List<BookModel> GetByGenres(string name)
    {
        return bookModelService.GetByGenres(name);
    }

    [HttpGet("autor/{name}")]
    public List<BookModel> GetByAuthor(string name)
    {
        return bookModelService.GetByAuthor(name);
    }

    [HttpGet("frete/{id}")]
    public double GetValueFrete(int id)
    {
        return bookModelService.GetValueFrete(id);
    }
}