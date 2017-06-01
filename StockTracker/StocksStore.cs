using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StockTracker
{
    public class StocksStore : E_IStocksStore
    {
        public void SaveStocks(IEnumerable<Stock> stocks)
        {
            string filename = GetCacheFilePath();

            var contents = String.Join(",", stocks.Select(stock => stock.ToString()));

            File.WriteAllText(filename, contents);
        }

        private string GetCacheFilePath()
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string filename = Path.Combine(folderPath, "stocks.dat");
            return filename;
        }

        public StockCollection LoadStocks()
        {
            List<Stock> ret = new List<Stock>();

            string filename = GetCacheFilePath();

            if (File.Exists(filename))
            {
                var contents = File.ReadAllText(filename);

                try
                {
                    ret = contents.Split(',')
                        .Select(s =>
                            new Stock(s.Split(':').First(),
                                Double.Parse(s.Split(':').Skip(1).First()),
                                Double.Parse(s.Split(':').Skip(2).First()),
                                s.Split(':').Skip(3).First()))
                        .ToList();
                }
                    // ReSharper disable once EmptyGeneralCatchClause
                catch (Exception)
                {

                }
            }

            return new StockCollection(ret);
        }
    }
}
