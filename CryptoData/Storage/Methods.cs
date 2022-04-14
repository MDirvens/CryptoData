using System;
using System.Collections.Generic;
using System.Linq;
using CryptoData.Models;
using Binance.Net.Objects.Models.Spot.Socket;
using CryptoExchange.Net.Sockets;

namespace CryptoData.Storage
{
    public class Methods
    {
        private readonly CryptoDataDbContext _context = new();
        private List<CryptoDataDto> _listToAdd = new();
        public List<CryptoDataDto> list = new();

        public void OnMessage(DataEvent<BinanceStreamBookPrice> data)
        {
           list.Add(Converter(data.Data, data.Timestamp));

            if (list.Count() == 100)
            {
                _listToAdd = list.OrderBy(o => o.OrderBookUpdateId).ToList();
                AddData(_listToAdd);
            }
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

        public void AddData(List<CryptoDataDto> listToAdd)
        { 
            list.RemoveRange(0, listToAdd.Count());
            _context.AddRange(listToAdd);
            _context.SaveChanges();
        }
    }
}