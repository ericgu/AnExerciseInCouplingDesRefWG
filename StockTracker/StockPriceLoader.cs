using System;
using System.Net;
// ReSharper disable StringIndexOfIsCultureSpecific.1

namespace StockTracker
{
    public delegate double GetStockPriceDelegate(string stockTicker);

    public class StockPriceLoader
    {
        public double Load(string stockTicker)
        {
            string url = String.Format("http://dev.markitondemand.com/MODApis/Api/v2/Quote/jsonp?symbol={0}",
                stockTicker);

            double price = 0;
            WebClient webClient = new WebClient();
            string result = webClient.DownloadString(url);
            if (!result.Contains("No symbol matches found"))
            {
                string lastPrice = result.Substring(result.IndexOf("LastPrice"));
                string pricePlus = lastPrice.Substring(lastPrice.IndexOf(":") + 1);
                string priceString = pricePlus.Substring(0, pricePlus.IndexOf(","));
                price = Double.Parse(priceString);
            }
            return price;
        }
    }
}