namespace Stocks.Information.ServiceContracts
{
    public interface IFinnhubService
    {
        public Task<Dictionary<string, object>?> GetStockPriceQuote(string symbol);
    }
}
