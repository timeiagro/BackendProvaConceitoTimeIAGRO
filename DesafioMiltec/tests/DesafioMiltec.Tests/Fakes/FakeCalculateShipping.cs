using DesafioMiltec.Domain.Interfaces;

namespace DesafioMiltec.Tests.Fakes
{
    internal sealed class FakeCalculateShipping : ICalculateShipping
    {
        public decimal Calculate(decimal price) => 0;
    }
}
