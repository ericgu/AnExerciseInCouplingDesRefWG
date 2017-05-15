namespace StockTracker
{
    public class StockValue
    {
        public StockValue(
            Stock stock,
            double price,
            double stockTotalPrice,
            double stockGain)
        {
            Stock = stock;
            Price = price;
            StockTotalPrice = stockTotalPrice;
            StockGain = stockGain;
        }

        public Stock Stock { get; }
        public double Price { get;  }
        public double StockTotalPrice { get; }
        public double StockGain { get; }
    }
}