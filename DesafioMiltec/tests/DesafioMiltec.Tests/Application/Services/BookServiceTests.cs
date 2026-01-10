using DesafioMiltec.Application.Services;
using DesafioMiltec.Application.Sorting;
using DesafioMiltec.Domain.Entities;
using DesafioMiltec.Tests.Fakes;
using System.Text.Json;

namespace DesafioMiltec.Tests.Application.Services
{
    public class BookServiceTests
    {
        private readonly BookService _service;

        public BookServiceTests()
        {
            var repository = new FakeBookRepository(GetBooks());
            var shipping = new FakeCalculateShipping();
            _service = new BookService(repository, shipping);
        }

        private static IReadOnlyCollection<Book> GetBooks()
     => new List<Book>
     {
        new()
        {
            Id = 1,
            Name = "Harry Potter",
            Price = 10,
            Specifications = new Dictionary<string, JsonElement>
            {
                ["Author"] = JsonDocument.Parse("\"J. K. Rowling\"").RootElement
            }
        },
        new()
        {
            Id = 2,
            Name = "The Hobbit",
            Price = 20,
            Specifications = new Dictionary<string, JsonElement>
            {
                ["Author"] = JsonDocument.Parse("\"J. R. R. Tolkien\"").RootElement
            }
        }
     };

        [Fact]
        public void GetById_Should_Return_Book_When_Exists()
        {
            // Teste 1 - Obter livro por ID existente

            // Act
            var book = _service.GetById(1);

            // Assert
            Assert.NotNull(book);

            Assert.Equal(1, book!.Id);
        }

        [Fact]
        public void GetById_Should_Return_Null_When_Not_Exists()
        {
            // Teste 2 — Obter livro por ID inexistente

            // Act
            var book = _service.GetById(99);

            // Assert
            Assert.Null(book);
        }


        [Fact] 
        public void Search_Should_Return_All_Books_When_Term_Is_Null()
        {
            // Teste 3 — Buscar todos os livros          

            // Act
            var result = _service.Search(null, new NoSort());

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void Search_Should_Filter_By_Name()
        {
            // Teste 4 — Buscar por nome            

            // Act
            var result = _service.Search("Harry", new NoSort());

            // Assert
            Assert.Single(result);
            Assert.Equal("Harry Potter", result.First().Name);
        }

        [Fact]
        public void Search_Should_Filter_By_Author()
        {
            // Teste 5 — Buscar por autor

            // Act
            var result = _service.Search("Tolkien", new NoSort());

            // Assert
            Assert.Single(result);
            Assert.Equal("The Hobbit", result.First().Name);
        }

        [Fact]
        public void Search_Should_Return_Empty_When_Term_Not_Found()
        {
            // Teste 6 — Buscar termo inexistente

            // Act   
            var result = _service.Search("Vulkan", new NoSort());

            // Assert
            Assert.Empty(result);
        }

    }
}
