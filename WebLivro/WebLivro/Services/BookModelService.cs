using WebLivro.Enum;
using WebLivro.repository;
using WebLivros.Interfaces;
using WebLivros.Models;

namespace WebLivros.Services;

public class BookModelService : IBookModelService
{
    private readonly IBookModelRepository _bookModelRepository;

    public BookModelService(IBookModelRepository bookModelRepository)
    {
        _bookModelRepository = bookModelRepository;
    }

    private readonly Func<AscDescEnum, List<BookModel>, List<BookModel>> ordenar = (ordem, list) =>
        ordem == AscDescEnum.Asc ? list.OrderBy(x => x.Price).ToList() : list.OrderByDescending(x => x.Price).ToList();

    public List<BookModel> GetBookModels(AscDescEnum ordem)
    {
       return ordenar(ordem, _bookModelRepository.GetBookModels());
    }

    public List<BookModel> GetByIllustrator(string illustrator)
    {
        return _bookModelRepository.GetByIllustrator(illustrator);
    }

    public List<BookModel> GetByName(string name)
    {
        return _bookModelRepository.GetByName(name);
    }

    public List<BookModel> GetByAuthor(string author)
    {
        return _bookModelRepository.GetByAuthor(author);
    }

    public List<BookModel> GetByGenres(string genres)
    {
        return _bookModelRepository.GetByGenres(genres);
    }

    public BookModel GetbyId(int id)
    {
        return _bookModelRepository.GetById(id);
    }

    public double GetValueFrete(int id)
    {
        var book = GetbyId(id);
        var frete = book.Price * 0.2;
        return Math.Round(frete, 2);
    }
}