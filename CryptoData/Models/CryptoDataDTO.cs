namespace CryptoData.Models
{
    public class CryptoDataDto
    {
        public int Id { get; set; }
        public string TimeStamp { get; set; }
        public long OrderBookUpdateId { get; set; }
        public string Symbol { get; set; }
        public decimal BestBidPrice { get; set; }
        public decimal BestBidQty { get; set; }
        public decimal BestAskPrice { get; set; }
        public decimal BestAskQty { get; set; }
    }
}
