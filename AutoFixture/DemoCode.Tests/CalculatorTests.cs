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

        [Fact]
        public void Manual_Anonymous_Data()
        {
            // Arrange
            var sut = new Calculator();
            var anonymousNumber = 394;

            // Act
            sut.Substract(anonymousNumber);

            // Assert
            Assert.True(sut.Value < 0);
        }
    }
}
