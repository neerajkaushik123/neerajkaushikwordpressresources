using System;

namespace TradingClientApp
{
	public class TradeReport
	{
		public string Id { get; set; }
		public DateTime TradeDate { get; set; }
		public string Message { get; set; }
		public decimal LastQty { get; set; }
		public decimal LastPrice { get; set; }
		public DateTime TransactTime { get; set; }
		public BuySellType Side { get; set; }
		public string OrderId { get; set; }
		public string ClientOrderId { get; set; }
		public string AccountId { get; set; }
		public int InstrumentId { get; set; }
		public string Symbol { get; set; }
	}
	public enum BuySellType
	{
		Buy,
		Sell,
		BuyLimit,
		SellLimit,
		None
	}
}