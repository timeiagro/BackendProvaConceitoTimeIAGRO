
using DesafioMiltec.Application.Services;

namespace DesafioMiltec.Tests.Application.Services
{
    public class CalculateShippingServiceTests
    {
        [Fact]
        public void Calculate_Should_Return_20_Percent_Of_Price()
        {
            // Arrange
            var service = new CalculateShippingService();
            var price = 100m;

            // Act
            var freight = service.Calculate(price);

            // Assert
            Assert.Equal(20m, freight);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void Calculate_Should_Throw_Exception_When_Price_Is_Invalid(decimal price)
        {
            // Arrange
            var service = new CalculateShippingService();

            // Act
            var exception = Assert.Throws<ArgumentException>(
                () => service.Calculate(price));

            // Assert
            Assert.Equal("O preço deve ser maior que zero", exception.Message);
        }
    }
}
