namespace FinanceTracker.Models
{
    public class TransactionType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // "Gelir" veya "Gider"
    }
}
