using Ploeh.AutoFixture;
using Xunit;

namespace DemoCode.Tests
{
    public class Numbers
    {
        [Fact]
        public void Ints()
        {
            // Arrange
            var fixture = new Fixture();
            var sut = new IntCalculator();
            int num = fixture.Create<int>();

            // Act
            sut.Add(num);

            // Assert
            Assert.Equal(num, sut.Value);
        }

        [Fact]
        public void Decimals()
        {
            // Arrange
            var fixture = new Fixture();
            var sut = new DecimalCalculator();

            decimal num = fixture.Create<decimal>();

            // Act
            sut.Add(num);

            // Assert
            Assert.Equal(num, sut.Value);
        }
    }
}
