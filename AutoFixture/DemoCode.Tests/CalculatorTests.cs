using Ploeh.AutoFixture;
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

        [Fact]
        public void Autofixture_Anonymous_Data()
        {
            // Arrange
            var sut = new Calculator();
            var fixture = new Fixture();

            // Act
            sut.Substract(fixture.Create<int>());

            // Assert
            Assert.True(sut.Value < 0);
        }

        [Fact]
        public void AddTwoPositiveNumbers()
        {
            var sut = new Calculator();

            sut.Add(1);
            sut.Add(2);

            Assert.Equal(3, sut.Value);
        }

        [Fact]
        public void AddZeroAndPositiveNumbers()
        {
            var sut = new Calculator();

            sut.Add(0);
            sut.Add(2);

            Assert.Equal(2, sut.Value);
        }

        [Fact]
        public void AddNegativeAndPositiveNumber()
        {
            var sut = new Calculator();

            sut.Add(-5);
            sut.Add(1);

            Assert.Equal(-4, sut.Value);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(0, 2)]
        [InlineData(-5, 1)]
        public void ShouldAdd_InlineData(int a, int b)
        {
            var sut = new Calculator();

            sut.Add(a);
            sut.Add(b);

            Assert.Equal(a + b, sut.Value);
        }
    }
}
