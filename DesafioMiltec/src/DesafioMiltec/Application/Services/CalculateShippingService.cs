using DesafioMiltec.Domain.Interfaces;

namespace DesafioMiltec.Application.Services
{
    public sealed class CalculateShippingService : ICalculateShipping
    {
        private const decimal ShippingRate = 0.20m;

        public decimal Calculate(decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("O preço deve ser maior que zero.", nameof(price));

            return Math.Round(price * ShippingRate, 2);
        }
    }
}
