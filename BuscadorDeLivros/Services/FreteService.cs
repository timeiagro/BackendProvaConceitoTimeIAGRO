namespace BuscadorDeLivros.Services
{
    public class FreteService : IFreteService
    {
        public decimal CalcularFrete(decimal bookPrice)
        {
            var valorDoFrete = bookPrice * (decimal)0.2;
            return valorDoFrete;
        }
    }
}
