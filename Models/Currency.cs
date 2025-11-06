namespace FinanceTracker.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty; // USD, EUR...
        public string Name { get; set; } = string.Empty; // Dolar, Euro...
        public decimal RateToTRY { get; set; }
        private DateTime? _lastUpdated;
        public DateTime LastUpdated
        {
            get => _lastUpdated ?? DateTime.Now;
            set => _lastUpdated = value;
        }
    }
}
