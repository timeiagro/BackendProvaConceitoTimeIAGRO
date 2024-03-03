using BuscadorDeLivros.Models;
using BuscadorDeLivros.Repositories;
using BuscadorDeLivros.Repository;

namespace BuscadorDeLivros.Testes.Unidade.Repositories
{
    [TestFixture]
    internal class BooksRepositoryTestes
    {
        private IBooksRepository _bookRepository;

        [SetUp]
        public void SetUp()
        {
            _bookRepository = new BooksRepository();
        }

        [Test]
        public void BuscarPorId_DeveRetornarBookCorrespondenteAoId() {
            var bookId = 1;

            var resultado = _bookRepository.BuscarPorId(bookId);

            Assert.Multiple(() =>
            {
                Assert.That(resultado, Is.Not.Null);
                Assert.That(resultado, Is.InstanceOf<Book>());
                Assert.That(resultado.Id, Is.EqualTo(bookId));
            });
        }

        [Test]
        public void BuscarPorId_DeveRetornarNulo_QuandoLivroNaoExistir()
        {
            var bookId = -1000;

            var resultado = _bookRepository.BuscarPorId(bookId);

            Assert.That(resultado, Is.Null);
        }

        [Test]
        public void BuscarTodos_DeveRetornarListaComTodosOsLivros()
        {
            var resultado = _bookRepository.BuscarTodos();

            Assert.Multiple(() =>
            {
                Assert.That(resultado, Is.Not.Null);
                Assert.That(resultado, Is.InstanceOf<List<Book>>());
                Assert.That(resultado.Any(), Is.True);
            });
        }
    }
}
