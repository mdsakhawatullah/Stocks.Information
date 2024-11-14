using Microsoft.AspNetCore.Mvc;
using Stocks.Information.Models;
using Stocks.Information.ServiceContracts;
using Stocks.Information.Services;
using System.Diagnostics;

namespace Stocks.Information.Controllers
{
    public class HomeController : Controller
    {
        private readonly FinnhubService _finnhubSerivce;
        public HomeController(FinnhubService finnhubService)
        {
            _finnhubSerivce = finnhubService;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            Dictionary<string, object>? responseDictionary =
            await _finnhubSerivce.GetStockPriceQuote("MSFT");
            return View();

        }
    }
}
