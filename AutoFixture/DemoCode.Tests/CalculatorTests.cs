using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit2;
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
        [AutoData]
        public void ShouldAdd_AutoData(int a, int b, Calculator sut)
        {
            sut.Add(a);
            sut.Add(b);

            Assert.Equal(a + b, sut.Value);
        }
    }
}
