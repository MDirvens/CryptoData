using System;
using System.Linq;
using Binance.Net.Objects.Models.Spot.Socket;
using CryptoData.Models;
using CryptoData.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoData.Tests
{
    [TestClass]
    public class MethodsTest
    {
        private Methods _methods;
        private CryptoDataDbContext _context;
        public BinanceStreamBookPrice receivedData;
        private DateTime time;
        private string stringTime;

        [TestInitialize]
        public void Setup()
        {
            _methods = new();
            _context = new();
            
            time = new(1487, 04, 11, 17, 13, 43, 861);
            stringTime = time.ToString("yyyy.MM.dd HH:mm:ss:fff");
        }

        [TestMethod]
        public void Converter_StartCryptoData_CryptoDataDto()
        {
            //Arange
            receivedData = new()
            {
                UpdateId = 400900217,
                Symbol = "BNBUSDT",
                BestBidPrice = 25.35190000m,
                BestBidQuantity = 31.21000000m,
                BestAskPrice = 25.36520000m,
                BestAskQuantity = 40.66000000m
            };

            //Act
            CryptoDataDto dbData = _methods.Converter(receivedData, time);

            //Assert
            Assert.AreEqual(stringTime, dbData.TimeStamp);
            Assert.AreEqual(receivedData.UpdateId, dbData.OrderBookUpdateId);
            Assert.AreEqual(receivedData.BestAskPrice,dbData.BestAskPrice);
            Assert.AreEqual(receivedData.BestAskQuantity, dbData.BestAskQty);
            Assert.AreEqual(receivedData.BestBidPrice, dbData.BestBidPrice);
            Assert.AreEqual(receivedData.BestBidQuantity, dbData.BestBidQty);
            Assert.AreEqual(receivedData.Symbol, dbData.Symbol);
        }

        [TestMethod]
        public void AddData_CryptoDataDto_DataIsInDb()
        {
            //Arange
            CryptoDataDto CryptoData = new()
            {
                TimeStamp = stringTime,
                OrderBookUpdateId = 400900217,
                Symbol = "BNBUSDT",
                BestBidPrice = 25.35190000m,
                BestBidQty = 31.21000000m,
                BestAskPrice = 25.36520000m,
                BestAskQty = 40.66000000m
            };
            int expected = _context.CryptoData.Count() + 1;

            //Act
            _methods.AddData(CryptoData);

            //Assert
            Assert.AreEqual(expected, _context.CryptoData.Count());
        }
    }
}