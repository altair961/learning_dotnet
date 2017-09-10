using Ploeh.AutoFixture;
using System;
using Xunit;

namespace DemoCode.Tests
{
    public class DatesAndTimes
    {
        [Fact]
        public void DateTimes()
        {
            // Arrange
            var fixture = new Fixture();
            DateTime logTime = fixture.Create<DateTime>();

            // Act
            LogMessage result = LogMessageCreator.Create(fixture.Create<string>(), logTime);

            // Assert
            Assert.Equal(logTime.Year, result.Year);
        }
    }
}
