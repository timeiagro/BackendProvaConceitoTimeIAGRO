namespace Hamurabi.Core.Models
{
    // Representa um livro do catálogo
    public class Book
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public BookSpecifications? Specifications { get; set; }

        // Calcula o valor do frete (20% do preço do livro)
        public decimal CalculateShipping()
        {
            return Price * 0.20m;
        }

        // Retorna o preço total (preço + frete)
        public decimal GetTotalPrice()
        {
            return Price + CalculateShipping();
        }
    }
}