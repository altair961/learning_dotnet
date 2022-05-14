using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using SqlConsumer.Core;
using System;
using System.Diagnostics;
using System.Threading;

namespace SqlConsumer.Tests
{
    [TestFixture]
    public class DatabaseStateTests
    {
        public string _connectionString;

        [SetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();
            _connectionString = config.GetConnectionString("db");
        }

        [Test]
        public void WithUsing()
        {
            using (var state = new DatabaseState(_connectionString))
            {
                Debug.WriteLine($"[{DateTime.Now.ToLongTimeString()}] GetDate; {state.GetDate()}");
            }
            Wait();
        }

        private void Wait()
        {
            Thread.Sleep(5 * 1000);
            Debug.WriteLine($"[{DateTime.Now.ToLongTimeString}] waited.");
        }
    }
}