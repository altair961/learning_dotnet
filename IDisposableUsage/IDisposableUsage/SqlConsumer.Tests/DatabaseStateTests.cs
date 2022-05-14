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
            _connectionString = config.GetConnectionString("db"); //db-max
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

        [Test]
        public void WithoutUsing()
        {
            var state = new DatabaseState(_connectionString);
            Debug.WriteLine($"[{DateTime.Now.ToLongTimeString()}] GetDate; {state.GetDate()}");
            Wait(); // during that wait period the connection is hold in the memory, which is bad. The connections number is finite. after app exists everything is released. But for long running service connection will be hold in memory for all that time while the service is running.
        }

        [Test]
        public void LoopWithUsing()
        {
            for (int i = 0; i < 1000; i++)
            {
                using var state = new DatabaseState(_connectionString);
                Debug.WriteLine($"[{DateTime.Now.ToLongTimeString()}] GetDate; {state.GetDate()}");
            }
            Wait();
        }

        [Test]
        public void LoopWithoutUsing() 
        {
            for (int i = 0; i < 1000; i++)
            {
                var state = new DatabaseState(_connectionString);
                Debug.WriteLine($"[{DateTime.Now.ToLongTimeString()}] GetDate; {state.GetDate()}");
            }
            Wait();
        }

        [Test]
        public void LoopWithCatch() 
        {
            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    var state = new DatabaseState(_connectionString);
                    Debug.WriteLine($"[{DateTime.Now.ToLongTimeString()}] GetDate; {state.GetDate()}");
                }
                Wait();
            }
            catch
            {
                GC.Collect(); // set a breackpoint here and request processes with a query from GettingNumberOfProcesses.sql
            }
        }

        private void Wait()
        {
            Thread.Sleep(5 * 1000);
            Debug.WriteLine($"[{DateTime.Now.ToLongTimeString}] waited.");
        }
    }
}