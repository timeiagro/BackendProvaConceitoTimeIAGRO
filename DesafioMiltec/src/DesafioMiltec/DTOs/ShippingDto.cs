namespace DesafioMiltec.DTOs
{
    public class ShippingDto
    {
        public int BookId { get; init; }
        public string BookName { get; init; } = string.Empty;
        public string BookPrice { get; init; } = string.Empty;
        public string Freight { get; init; } = string.Empty;
    }
}
