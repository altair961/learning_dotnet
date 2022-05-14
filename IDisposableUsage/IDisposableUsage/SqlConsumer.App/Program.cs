using Microsoft.Extensions.Configuration;
using SqlConsumer.Core;

namespace SqlConsumer.App
{
    class Program
    {
        private static DatabaseState _DatabaseState;
        private static IConfiguration _Config;

        static void Main(string[] args)
        {
            _Config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();

            _DatabaseState = new DatabaseState(_Config);
        }
    }
}