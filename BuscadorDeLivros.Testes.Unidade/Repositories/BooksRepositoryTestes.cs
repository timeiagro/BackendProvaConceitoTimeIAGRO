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
        public async Task BuscarPorId_DeveRetornarBookCorrespondenteAoId() {
            var bookId = 1;

            var resultado = await _bookRepository.BuscarPorIdAsync(bookId);

            Assert.Multiple(() =>
            {
                Assert.That(resultado, Is.Not.Null);
                Assert.That(resultado, Is.InstanceOf<Book>());
                Assert.That(resultado.Id, Is.EqualTo(bookId));
            });
        }

        [Test]
        public async Task BuscarPorId_DeveRetornarNulo_QuandoLivroNaoExistir()
        {
            var bookId = -1000;

            var resultado = await _bookRepository.BuscarPorIdAsync(bookId);

            Assert.That(resultado, Is.Null);
        }

        [Test]
        public async Task BuscarTodos_DeveRetornarListaDeLivros()
        {
            var resultado = await _bookRepository.BuscarTodosAsync();

            Assert.Multiple(() =>
            {
                Assert.That(resultado, Is.Not.Null);
                Assert.That(resultado, Is.InstanceOf<List<Book>>());
                Assert.That(resultado.Any(), Is.True);
            });
        }
    }
}
