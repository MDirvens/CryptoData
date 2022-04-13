using System;
using CryptoData.Models;
using Binance.Net.Objects.Models.Spot.Socket;

namespace CryptoData.Storage
{
    public class Methods
    {
        private static readonly CryptoDataDbContext _context = new();

        public void OnMessage(BinanceStreamBookPrice data, DateTime timeStamp)
        {
            AddData(Converter(data, timeStamp));
        }

        public CryptoDataDto Converter(BinanceStreamBookPrice data, DateTime timeStamp)
        {
            CryptoDataDto returnData = new()
            {
                TimeStamp = timeStamp.ToString("yyyy.MM.dd HH:mm:ss:fff"),
                OrderBookUpdateId = data.UpdateId,
                Symbol = data.Symbol,
                BestBidPrice = data.BestBidPrice,
                BestBidQty = data.BestBidQuantity,
                BestAskPrice = data.BestAskPrice,
                BestAskQty = data.BestAskQuantity
            };

            return returnData;
        }

        public void AddData(CryptoDataDto data)
        {
            _context.Add(data);
            _context.SaveChanges();
        }
    }
}