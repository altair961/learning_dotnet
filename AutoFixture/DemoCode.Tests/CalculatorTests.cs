using Xunit;

namespace DemoCode.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Traditional()
        {
            // Arrange
            var sut = new Calculator();

            // Act
            sut.Substract(1);

            // Assert
            Assert.True(sut.Value < 0);
        }
    }
}
