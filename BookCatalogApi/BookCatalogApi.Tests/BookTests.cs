using BookCatalogApi.Models;
using FluentAssertions;

namespace BookCatalogApi.Tests;

public class BookTests
{
    [Fact]
    public void CalculateShippingCost_WithDefaultPercentage_ReturnsCorrectValue()
    {
        var book = new Book { Price = 10.00m };

        var shippingCost = book.CalculateShippingCost();

        shippingCost.Should().Be(2.00m);
    }

    [Fact]
    public void CalculateShippingCost_WithCustomPercentage_ReturnsCorrectValue()
    {
        var book = new Book { Price = 10.00m };

        var shippingCost = book.CalculateShippingCost(0.15m);

        shippingCost.Should().Be(1.50m);
    }

    [Theory]
    [InlineData(10.00, 0.20, 2.00)]
    [InlineData(7.31, 0.20, 1.46)]
    [InlineData(6.15, 0.20, 1.23)]
    [InlineData(11.15, 0.20, 2.23)]
    [InlineData(100.00, 0.10, 10.00)]
    public void CalculateShippingCost_WithVariousPrices_ReturnsCorrectValue(
        decimal price, 
        decimal percentage, 
        decimal expectedShipping)
    {
        var book = new Book { Price = price };

        var shippingCost = book.CalculateShippingCost(percentage);

        shippingCost.Should().Be(expectedShipping);
    }

    [Fact]
    public void CalculateShippingCost_WithDecimalPrice_RoundsToTwoDecimals()
    {
        var book = new Book { Price = 7.31m };

        var shippingCost = book.CalculateShippingCost();

        shippingCost.Should().Be(1.46m);
    }

    [Fact]
    public void CalculateShippingCost_WithZeroPrice_ReturnsZero()
    {
        var book = new Book { Price = 0m };

        var shippingCost = book.CalculateShippingCost();

        shippingCost.Should().Be(0m);
    }

    [Fact]
    public void CalculateShippingCost_WithNegativePercentage_ThrowsArgumentException()
    {
        var book = new Book { Price = 10.00m };

        var act = () => book.CalculateShippingCost(-0.10m);

        act.Should().Throw<ArgumentException>()
            .WithParameterName("percentage")
            .WithMessage("*cannot be negative*");
    }

    [Fact]
    public void CalculateShippingCost_WithLargePrice_HandlesCorrectly()
    {
        var book = new Book { Price = 999999.99m };

        var shippingCost = book.CalculateShippingCost();

        shippingCost.Should().Be(200000.00m);
    }
}
