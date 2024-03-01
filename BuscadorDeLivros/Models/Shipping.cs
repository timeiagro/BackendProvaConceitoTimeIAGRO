namespace BuscadorDeLivros.Models
{
    public class Shipping
    {
        public int BookId { get; set; }
        public decimal BookPrice { get; set; }
        public decimal ShippingValue { get; set;}
    }
}
