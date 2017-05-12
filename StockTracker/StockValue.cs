namespace StockTracker
{
    public class StockValue
    {
        public StockValue(Stock stock, double price)
        {
            Stock = stock;
            Price = price;
        }

        private Stock Stock { get; }
        private double Price { get; }

        public double GetStockGain()
        {
            return Stock.Shares * (Price - Stock.PurchasePrice);
        }

        public double GetStockTotalPrice()
        {
            return Stock.Shares * Price;
        }
    }
}