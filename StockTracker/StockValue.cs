namespace StockTracker
{
    public class StockValue
    {
        public StockValue(Stock stock, double price)
        {
            Stock = stock;
            Price = price;
            Gain = Stock.Shares * (Price - Stock.PurchasePrice);
            TotalPrice = Stock.Shares * Price;
        }

        private Stock Stock { get; }
        private double Price { get; }

        public double Gain { get; }

        public double TotalPrice { get; }
    }
}