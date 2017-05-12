namespace StockTracker
{
    public class StockValue
    {
        public StockValue(Stock stock, double price)
        {
            Stock = stock;
            Price = price;
        }

        public Stock Stock { get; private set; }
        public double Price { get; private set; }
    }
}