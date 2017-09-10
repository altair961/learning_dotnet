using Ploeh.AutoFixture;
using Xunit;

namespace DemoCode.Tests
{
    public class Strings
    {
        [Fact]
        public void BasicString()
        {
            // Arrange
            var fixture = new Fixture();
            var sut = new NameJoiner();

            var firstName = fixture.Create<string>();
            var lastName = fixture.Create<string>();

            // Act
            var result = sut.Join(firstName, lastName);

            // Assert
            Assert.Equal(firstName + ' ' + lastName, result);
        }
    }
}
