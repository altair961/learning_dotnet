using Ploeh.AutoFixture;
using System;
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

            IEnumerable<int> messages = fixture.CreateMany<int>(6);

            foreach (var message in messages)
            {
                Debug.WriteLine(message);
            }
        }

        [Fact]
        public void AddingToExistingList()
        {
            var fixture = new Fixture();
            var sut = new DebugMessageBuffer();
            fixture.AddManyTo(sut.Messages, 10);
            sut.WriteMessages();
        }

        [Fact]
        public void AddingToExistingListWithCreatorFunction()
        {
            var fixture = new Fixture();
            var sut = new DebugMessageBuffer();
            var rnd = new Random();
                
            //fixture.AddManyTo(sut.Messages, () => "hi");
            fixture.AddManyTo(sut.Messages, () => rnd.Next(11).ToString());
            sut.WriteMessages();
        }
    }
}
