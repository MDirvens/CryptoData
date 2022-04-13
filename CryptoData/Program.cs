using System;
using CryptoData.Storage;
using Binance.Net.Clients;
using Binance.Net.Objects;

namespace CryptoData
{
    class Program
    {
        private static string symbol = "BTCUSDT";
        private static Methods _methods = new();
        private static readonly object _lock = new();

        static void Main(string[] args)
        {
            var client = new BinanceSocketClient(new BinanceSocketClientOptions()
            {
                AutoReconnect = true,
            });

            client.SpotStreams.SubscribeToBookTickerUpdatesAsync(symbol, data =>
            {
                lock (_lock)
                {
                    _methods.OnMessage(data.Data, data.Timestamp);
                }
            });
            
            Console.ReadKey();
        }
    }
}
