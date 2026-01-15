using Arbooks.Business.Services;

namespace Arbooks.Test.Business
{
    public class ShippingServiceTests
    {
        [Fact] // Indica que este é um método de teste
        public void Calculate_Correct()
        {
            // Arrange (Preparar)
            var calc = new ShippingService();
            int price = 200;
            decimal espected = 40;

            // Act (Agir)
            decimal result = calc.Calculate(price);

            // Assert (Verificar)
            Assert.Equal(espected, result);
        }
    }

}