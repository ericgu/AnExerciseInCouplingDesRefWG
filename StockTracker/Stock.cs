namespace StockTracker
{
    public class Stock
    {
        public Stock(string ticker, double shares)
        {
            Ticker = ticker;
            Shares = shares;
        }

        public string Ticker { get; }
        public double Shares { get; }
    }
}