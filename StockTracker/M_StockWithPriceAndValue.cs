// Design discussion comments:
// Add your comment here, in this format:
// <alias>: comment

using System;

namespace StockTracker
{
    public class M_StockWithPriceAndValue
    {
        public Stock Stock { get; set; }

        public double Price { get; set; }

        public double CurrentValue { get; set; }

        public double Gain { get; set; }
    }
}