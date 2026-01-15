namespace Arbooks.Business.Services
{
    public class ShippingService
    {
        public decimal Calculate(decimal price)
        {
            return price * 0.2m;
        }
    }
}