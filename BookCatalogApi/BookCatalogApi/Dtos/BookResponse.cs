namespace BookCatalogApi.Dtos;

public class BookResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal TotalPrice => Price + ShippingCost;
    public BookSpecificationResponse Specifications { get; set; } = new();
}
