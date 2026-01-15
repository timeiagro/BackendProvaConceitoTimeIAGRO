namespace Arbooks.Business.DTOs
{
    public class BookDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public SpecificationDTO specifications { get; set; }
    }
}