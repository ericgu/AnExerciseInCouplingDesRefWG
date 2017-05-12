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

        public double GetGain()
        {
            return Stock.Shares * (Price - Stock.PurchasePrice);
        }

        public double GetTotalPrice()
        {
            return Stock.Shares * Price;
        }
    }
}