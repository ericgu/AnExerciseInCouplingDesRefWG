using System;
using System.Windows.Forms;

namespace StockTracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(
                new Form1(
                    new StocksStore(),
                    new GainModel(new StockPriceLoader()),
                    new StockPriceLoader().Load));
        }
    }
}
