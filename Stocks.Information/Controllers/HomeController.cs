using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stocks.Information.Models;
using Stocks.Information.ServiceContracts;
using Stocks.Information.Services;
using System.Diagnostics;

namespace Stocks.Information.Controllers
{
    public class HomeController : Controller
    {
        private readonly FinnhubService _finnhubSerivce;
        private readonly IOptions<TradingOptions> _tradingOptions;
        public HomeController(FinnhubService finnhubService, IOptions<TradingOptions> tradingOptions)
        {
            _finnhubSerivce = finnhubService;
            _tradingOptions = tradingOptions;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            if (_tradingOptions.Value.DefaultStockSymbol == null)
            {
                _tradingOptions.Value.DefaultStockSymbol = "MSFT";
            }
            Dictionary<string, object>? responseDictionary =
            await _finnhubSerivce.GetStockPriceQuote(_tradingOptions.Value.DefaultStockSymbol);



            Stock stock = new Stock()
            {
                StockSymbol = _tradingOptions.Value.DefaultStockSymbol,
                CurrentPrice = Convert.ToDouble(responseDictionary["c"].ToString()),
                LowestPrice = Convert.ToDouble(responseDictionary["l"].ToString()),
                HighestPrice = Convert.ToDouble(responseDictionary["h"].ToString()),
                OpenPrice = Convert.ToDouble(responseDictionary["o"].ToString())

            };

            return View(stock);

        }
    }
}
