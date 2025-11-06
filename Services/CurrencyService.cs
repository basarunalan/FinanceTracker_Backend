using StackExchange.Redis;
using System.Text.Json;

namespace FinanceTracker.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _db;

        public CurrencyService(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _db = _redis.GetDatabase();
        }

        public async Task<Dictionary<string, decimal>> GetLatestRatesAsync()
        {
            var value = await _db.StringGetAsync("currency_rates");

            if (value.IsNullOrEmpty)
            {
                // Redis'te veri yoksa boş sözlük döndür
                return new Dictionary<string, decimal>();
            }

#pragma warning disable CS8604 // Possible null reference argument.
            return JsonSerializer.Deserialize<Dictionary<string, decimal>>(value)
                   ?? new Dictionary<string, decimal>();
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public async Task SetRatesAsync(Dictionary<string, decimal> rates)
        {
            var json = JsonSerializer.Serialize(rates);
            await _db.StringSetAsync("currency_rates", json);
        }
    }
}
