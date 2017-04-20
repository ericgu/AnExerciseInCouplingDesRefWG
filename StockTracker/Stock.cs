namespace StockTracker
{
    public class Stock
    {
        private string _ticker;

        public Stock(string ticker)
        {
            _ticker = ticker;
        }

        public string Ticker
        {
            get { return _ticker; }
        }
    }
}