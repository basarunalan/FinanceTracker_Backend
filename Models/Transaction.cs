using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }  // Primary Key

        public string Title { get; set; } = string.Empty; // İşlemin başlığı (ör: "Maaş", "Kira Ödemesi")

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        // 🔹 Foreign Key: Currency
        public int CurrencyId { get; set; }
        public Currency? Currency { get; set; }

        // 🔹 Foreign Key: TransactionType
        public int TransactionTypeId { get; set; }
        public TransactionType? TransactionType { get; set; } // navigation, zorunlu değil

    }
}

