namespace StockTracker
{
    public class StockValue
    {
        public StockValue(Stock stock, double price)
        {
            Gain = stock.Shares * (price - stock.PurchasePrice);
            TotalPrice = stock.Shares * price;
        }

        public double Gain { get; }

        public double TotalPrice { get; }
    }
}