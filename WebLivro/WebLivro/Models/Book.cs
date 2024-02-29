namespace WebLivros.Models
{
    public class Book
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public double price { get; set; }
        public Specifications specifications { get; set; }

    }
}
