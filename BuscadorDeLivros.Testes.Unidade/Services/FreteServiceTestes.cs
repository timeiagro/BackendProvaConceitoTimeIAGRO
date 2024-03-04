using BuscadorDeLivros.Services;

namespace BuscadorDeLivros.Testes.Unidade.Services
{
    [TestFixture]
    internal class FreteServiceTestes
    {
        private IFreteService _freteService;

        [SetUp]
        public void Setup()
        {
            _freteService = new FreteService();
        }

        [Test]
        [TestCase(2.31d)]
        [TestCase(95.54d)]
        [TestCase(346.25d)]
        public void CalcularFrete_DeveRetornarValorDoFrete(decimal bookPrice)
        {
            var resultado = _freteService.CalcularFrete(bookPrice);

            var valorDeFreteEsperado = bookPrice * (decimal)0.2;
            Assert.That(resultado, Is.EqualTo(valorDeFreteEsperado));
        }
    }
}
