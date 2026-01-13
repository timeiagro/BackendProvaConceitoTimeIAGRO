using System.Collections.Generic;
using CatalogoLivros.Api.Models;

namespace CatalogoLivros.Api.Services
{
  public interface IBookService
{
    List<Book> Search(string? title, string? author, string? sort);
    double CalculateFreight(long id);
}
}
