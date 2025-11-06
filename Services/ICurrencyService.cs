using FinanceTracker.Models;

namespace FinanceTracker.Services
{
    public interface ICurrencyService
    {
        Task<Dictionary<string, decimal>> GetLatestRatesAsync();
        Task SetRatesAsync(Dictionary<string, decimal> rates);
    }
}
