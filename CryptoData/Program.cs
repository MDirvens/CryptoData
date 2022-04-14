using System;
using CryptoData.Storage;
using Binance.Net.Clients;
using Binance.Net.Objects;

namespace CryptoData
{
    class Program
    {
        private static readonly string _symbol = "BTCUSDT";
        private static readonly Methods _methods = new();

        static void Main(string[] args)
        {
            var client = new BinanceSocketClient(new BinanceSocketClientOptions()
            {
                AutoReconnect = true,
            });

            client.SpotStreams.SubscribeToBookTickerUpdatesAsync(_symbol, data =>
            {
                Console.WriteLine(data.Timestamp);
                _methods.OnMessage(data); 
            });
            
            Console.ReadKey();
        }
    }
}
