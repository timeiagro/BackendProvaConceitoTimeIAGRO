using BuscadorDeLivros.Controllers;
using BuscadorDeLivros.Models;
using BuscadorDeLivros.Repositories;
using BuscadorDeLivros.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BuscadorDeLivros.Testes.Unidade.Controllers
{
    [TestFixture]
    internal class BooksControllerTestes
    {
        private BooksController _booksController;
        private Mock<IBooksRepository> _booksRepositoryMock;
        private Mock<IFreteService> _freteServiceMock;

        [SetUp]
        public void Setup()
        {
            _booksRepositoryMock = new Mock<IBooksRepository>();
            _freteServiceMock = new Mock<IFreteService>();
            _booksController = new BooksController(_booksRepositoryMock.Object, _freteServiceMock.Object);
        }

        [Test]
        public void Buscar_DeveRetornarOkEListaVazia_QuandoNaoExistirLivros()
        {
            _booksRepositoryMock.Setup(m => m.BuscarTodos()).Returns(()=>null);

            var resultado = _booksController.Buscar(null, null, null, null).Result as ObjectResult;

            Assert.Multiple(() =>
            {
                Assert.That(resultado, Is.Not.Null);
                Assert.That(resultado?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
                Assert.AreEqual((resultado?.Value as List<Book>).Count, 0);
            });
        }

        [Test]
        public void Buscar_DeveRetornarOkETodosOsLivros_QuandoNaoExistirFiltro()
        {
            var books = new List<Book>()
            {
                new Book(){ Id = 1, Name = "Livro A", Price = 32.12m},
                new Book(){ Id = 2, Name = "Livro B", Price = 25.20m},
                new Book(){ Id = 3, Name = "Livro C", Price = 12.60m},
            };
            _booksRepositoryMock.Setup(m => m.BuscarTodos()).Returns(books);

            var resultado = _booksController.Buscar(null, null, null, null).Result as OkObjectResult;

            Assert.Multiple(() =>
            {
                Assert.That(resultado, Is.Not.Null);
                Assert.That(resultado?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
                Assert.AreEqual((resultado?.Value as List<Book>).Count, 3);
            });
        }

        [Test]
        public void Buscar_DeveRetornarOKELivrosFiltradosPorNome_QuandoOParametroNomeExistir()
        {
            var books = new List<Book>()
            {
                new Book(){ Id = 1, Name = "Livro A", Price = 32.12m},
                new Book(){ Id = 2, Name = "Livro B", Price = 25.20m},
                new Book(){ Id = 3, Name = "Livro C", Price = 12.60m},
            };
            _booksRepositoryMock.Setup(m => m.BuscarTodos()).Returns(books);

            var resultado = _booksController.Buscar("Livro B", null, null, null)?.Result as OkObjectResult;

            Assert.Multiple(() =>
            {
                Assert.That(resultado, Is.Not.Null);
                Assert.That(resultado.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
                Assert.That(1, Is.EqualTo((resultado.Value as List<Book>).Count));
                Assert.That(2, Is.EqualTo((resultado.Value as List<Book>).FirstOrDefault().Id));
                Assert.That("Livro B", Is.EqualTo((resultado.Value as List<Book>).FirstOrDefault().Name));
            });
        }

        [Test]
        public void Buscar_DeveRetornarOKELivrosFiltradosPorPreco_QuandoOParametroPrecoExistir()
        {
            var books = new List<Book>()
            {
                new Book(){ Id = 1, Name = "Livro A", Price = 32.12m},
                new Book(){ Id = 2, Name = "Livro B", Price = 25.20m},
                new Book(){ Id = 3, Name = "Livro C", Price = 12.60m},
            };
            _booksRepositoryMock.Setup(m => m.BuscarTodos()).Returns(books);

            var resultado = _booksController.Buscar(null, 12.60m, null, null)?.Result as OkObjectResult;
            var valor = resultado?.Value as List<Book>;

            Assert.Multiple(() =>
            {
                Assert.That(resultado, Is.Not.Null);
                Assert.That(resultado.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
                Assert.That(valor.Count, Is.EqualTo(1));
                Assert.That(valor.FirstOrDefault().Id, Is.EqualTo(3));
                Assert.That(valor.FirstOrDefault().Name, Is.EqualTo("Livro C"));
            });
        }

        [Test]
        public void Buscar_DeveRetornarOKELivrosFiltradosPorGenero_QuandoOParametroGeneroExistir()
        {
            var books = new List<Book>()
            {
                new Book(){ Id = 1, Name = "Livro A", Price = 32.12m, Specifications = new BookSpecifications(){Genres = "Ação"} },
                new Book(){ Id = 2, Name = "Livro B", Price = 25.20m, Specifications = new BookSpecifications(){Genres = "Aventura"} },
                new Book(){ Id = 3, Name = "Livro C", Price = 12.60m, Specifications = new BookSpecifications(){Genres = "Terror"} },
            };
            _booksRepositoryMock.Setup(m => m.BuscarTodos()).Returns(books);

            var resultado = _booksController.Buscar(null, null, "Aventura", null)?.Result as OkObjectResult;
            var valor = resultado?.Value as List<Book>;

            Assert.Multiple(() =>
                {
                    Assert.That(resultado, Is.Not.Null);
                    Assert.That(resultado.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
                    Assert.That(1, Is.EqualTo(valor.Count));
                    Assert.That(2, Is.EqualTo(valor.FirstOrDefault().Id));
                    Assert.That("Livro B", Is.EqualTo(valor.FirstOrDefault().Name));
                });
        }

        [Test]
        public void Buscar_DeveRetornarOKELivrosOrdenadosPorPrecoAsc_QuandoOParametroOrdenarPrecoAscExistir()
        {
            var books = new List<Book>()
            {
                new Book(){ Id = 1, Name = "Livro A", Price = 32.12m, },
                new Book(){ Id = 2, Name = "Livro B", Price = 25.20m, },
                new Book(){ Id = 3, Name = "Livro C", Price = 12.60m, },
            };
            _booksRepositoryMock.Setup(m => m.BuscarTodos()).Returns(books);

            var resultado = _booksController.Buscar(null, null, null, "asc")?.Result as OkObjectResult;
            var valor = resultado?.Value as List<Book>;

            Assert.Multiple(() =>
            {
                Assert.That(resultado, Is.Not.Null);
                Assert.That(resultado.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
                Assert.That(3, Is.EqualTo(valor.Count));
                Assert.That("Livro C", Is.EqualTo(valor.FirstOrDefault().Name));
                Assert.That("Livro A", Is.EqualTo(valor.LastOrDefault().Name));
            });
        }

        [Test]
        public void Buscar_DeveRetornarOKELivrosOrdenadosPorPrecoDesc_QuandoOParametroOrdenarPrecoDescExistir()
        {
            var books = new List<Book>()
            {
                new Book(){ Id = 1, Name = "Livro A", Price = 32.12m, },
                new Book(){ Id = 2, Name = "Livro B", Price = 25.20m, },
                new Book(){ Id = 3, Name = "Livro C", Price = 12.60m, },
            };
            _booksRepositoryMock.Setup(m => m.BuscarTodos()).Returns(books);

            var resultado = _booksController.Buscar(null, null, null, "desc")?.Result as OkObjectResult;
            var valor = resultado?.Value as List<Book>;

            Assert.Multiple(() =>
            {
                Assert.That(resultado, Is.Not.Null);
                Assert.That(resultado.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
                Assert.That(3, Is.EqualTo(valor.Count));
                Assert.That("Livro A", Is.EqualTo(valor.FirstOrDefault().Name));
                Assert.That("Livro C", Is.EqualTo(valor.LastOrDefault().Name));
            });
        }

        [Test]
        public void Buscar_DeveRetornarBadRequest_QuandoOParametroOrdenarPorPrecoForInvalido()
        {
            var books = new List<Book>()
            {
                new Book(){ Id = 1, Name = "Livro A", Price = 32.12m, },
                new Book(){ Id = 2, Name = "Livro B", Price = 25.20m, },
                new Book(){ Id = 3, Name = "Livro C", Price = 12.60m, },
            };
            _booksRepositoryMock.Setup(m => m.BuscarTodos()).Returns(books);

            var resultado = _booksController.Buscar(null, null, null, "ABC")?.Result as BadRequestObjectResult;

            Assert.Multiple(() =>
            {
                Assert.That(resultado, Is.Not.Null);
                Assert.That(resultado.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
                Assert.That(resultado.Value, Is.EqualTo("OrdenarPorPreco deve receber apenas os parâmetros \"asc\" ou \"desc\" "));
            });
        }

        [Test]
        public void Buscar_DeveRetornarStatus500_DeveRetornarStatus500_QuanddoOcorrerErro()
        {
            _booksRepositoryMock.Setup(m => m.BuscarTodos()).Throws(new Exception());

            var resultado = _booksController.Buscar(null, null, null, null)?.Result as ObjectResult;

            Assert.Multiple(() =>
            {
                Assert.That(resultado, Is.Not.Null);
                Assert.That(resultado.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
                Assert.That("Ocorreu um erro no sistema.", Is.EqualTo(resultado.Value));
            });
        }

        [Test]
        public void CalcularFrete_DeveRetornarOkEValorDoFrete()
        {
            var book = new Book
            {
                Id = 1,
                Name = "TestBook",
                Price = 31.24m,
                Specifications = { }
            };
            var valorDoFrete = book.Price * (decimal)0.2;

            _booksRepositoryMock.Setup(m => m.BuscarPorId(book.Id)).Returns(book);
            _freteServiceMock.Setup(m => m.CalcularFrete(book.Price)).Returns(valorDoFrete);

            var resultado = _booksController.CalcularFrete(book.Id).Result as OkObjectResult;

            Assert.Multiple(() =>
            {
                Assert.That(resultado?.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
                Assert.That(valorDoFrete, Is.EqualTo((resultado?.Value as Shipping)?.ShippingValue));
            });
        }

        [Test]
        public void CalcularFrete_DeveRetornarNotFound_QuandoLivroNaoExistir()
        {
            var bookId = -1999;
            _booksRepositoryMock.Setup(m => m.BuscarPorId(bookId)).Returns(() => null);

            var resultado = _booksController.CalcularFrete(bookId).Result;

            Assert.Multiple(() =>
            {
                Assert.That((resultado as NotFoundObjectResult)?.StatusCode, Is.EqualTo(StatusCodes.Status404NotFound));
                Assert.That((resultado as NotFoundObjectResult)?.Value, Is.EqualTo("Livro não encontrado."));
            });
        }

        [Test]
        public void CalcularFrete_DeveRetornarStatus500_QuanddoOcorrerErro()
        {
            var bookId = 1;
            _booksRepositoryMock.Setup(m => m.BuscarPorId(bookId)).Throws(new Exception());

            var resultado = _booksController.CalcularFrete(bookId).Result;

            Assert.Multiple(() =>
            {
                Assert.That((resultado as ObjectResult)?.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
                Assert.That((resultado as ObjectResult)?.Value, Is.EqualTo("Ocorreu um erro no sistema."));
            });
        }
    }
}
