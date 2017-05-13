using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StockTracker
{
    internal class StocksFileRepository
    {
        public void SaveStocks(IEnumerable<Stock> stocks)
        {
            string filename = GetCacheFilePath();

            var contents = String.Join(",", stocks.Select(stock => stock.ToString()));

            File.WriteAllText(filename, contents);
        }

        public List<Stock> LoadStocks()
        {
            string filename = GetCacheFilePath();

            if (File.Exists(filename))
            {
                var contents = File.ReadAllText(filename);

                try
                {
                    return contents.Split(',')
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

            return new List<Stock>();
        }

        private string GetCacheFilePath()
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string filename = Path.Combine(folderPath, "stocks.dat");
            return filename;
        }
    }
}
