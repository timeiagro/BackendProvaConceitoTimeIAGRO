using CatalogoLivros.Api.Models;
using CatalogoLivros.Api.Repositories;
using CatalogoLivros.Api.Services;
using FluentAssertions;
using Moq;
using Xunit;

public class BookServiceTests
{
    [Fact]
    public void Deve_retornar_apenas_livros_do_autor_Jules_Verne()
    {
        // Arrange
        var books = new List<Book>
        {
            new()
            {
                Id = 1,
                Title = "Journey",
                Price = 10,
                Specifications = new  BookSpecifications { Author = "Jules Verne" }
            },
            new()
            {
                Id = 2,
                Title = "20000 Leagues",
                Price = 12,
                Specifications = new  BookSpecifications { Author = "Jules Verne" }
            },
            new()
            {
                Id = 3,
                Title = "Dracula",
                Price = 15,
                Specifications = new  BookSpecifications { Author = "Bram Stoker" }
            }
        };

        var repoMock = new Mock<IBookRepository>();
        repoMock.Setup(r => r.GetAll()).Returns(books);

        var service = new BookService(repoMock.Object);

        // Act
        var result = service.Search(null, "Jules", null);

        // Assert
        result.Should().HaveCount(2);
        result.All(b => b.Specifications.Author == "Jules Verne").Should().BeTrue();
    }

    [Fact]
    public void Deve_retornar_todos_os_livros_quando_author_for_nulo()
    {
        // Arrange
        var books = new List<Book>
        {
            new() { Specifications = new  BookSpecifications{ Author = "Jules Verne" } },
            new() { Specifications = new  BookSpecifications{ Author = "Bram Stoker" } },
            new() { Specifications = new  BookSpecifications { Author = "Machado de Assis" } }
        };

        var repoMock = new Mock<IBookRepository>();
        repoMock.Setup(r => r.GetAll()).Returns(books);

        var service = new BookService(repoMock.Object);

        // Act
        var result = service.Search(null, null, null);

        // Assert
        result.Should().HaveCount(3);
    }

    [Fact]
    public void CalculateFreight_deve_retornar_20_porcento_do_preco()
    {
        // Arrange
        var book = new Book
        {
            Id = 1,
            Price = 100
        };

        var repoMock = new Mock<IBookRepository>();
        repoMock.Setup(r => r.GetById(1)).Returns(book);

        var service = new BookService(repoMock.Object);

        // Act
        var freight = service.CalculateFreight(1);

        // Assert
        freight.Should().Be(20);
    }
}
