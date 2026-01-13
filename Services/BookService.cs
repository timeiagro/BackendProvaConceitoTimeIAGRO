using System;
using System.Collections.Generic;
using System.Linq;
using CatalogoLivros.Api.Models;
using CatalogoLivros.Api.Repositories;

namespace CatalogoLivros.Api.Services
{
    //regras de negócio (buscar, ordenar, calcular frete)
public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public List<Book> Search(string? title, string? author, string? sort)
    {
        var books = _repository.GetAll();

        if (!string.IsNullOrWhiteSpace(title))
            books = books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();

        if (!string.IsNullOrWhiteSpace(author))
        books = books
            .Where(b => b.Specifications.Author
                .Contains(author, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (sort?.ToLower() == "asc")
            books = books.OrderBy(b => b.Price).ToList();
        else if (sort?.ToLower() == "desc")
            books = books.OrderByDescending(b => b.Price).ToList();

        return books;
    }

    public double CalculateFreight(long id)
    {
        var book = _repository.GetById(id);

        if (book == null)
            throw new Exception("Livro não encontrado");

        return book.Price * 0.20;
    }
}
}