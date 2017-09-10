using Ploeh.AutoFixture;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace DemoCode.Tests
{
    public class Collections
    {
        [Fact]
        public void SequenceOfStrings()
        {
            var fixture = new Fixture();

            IEnumerable<string> messages = fixture.CreateMany<string>();

            foreach (var message in messages)
            {
                Debug.WriteLine(message);   
            }
        }

        [Fact]
        public void ExplicitNumberOfItems()
        {
            var fixture = new Fixture();

            IEnumerable<string> messages = fixture.CreateMany<string>(6);

            foreach (var message in messages)
            {
                Debug.WriteLine(message);
            }
        }
    }
}
