using FinanceTracker.Data;
using FinanceTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransactionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/transaction
        [HttpGet("Summary")]
        public async Task<IActionResult> GetTransactions()
        {
            var transactions = await _context.Transactions
                .Include(t => t.Currency)
                .Include(t => t.TransactionType)
                .ToListAsync();

            return Ok(transactions);
        }

        // POST: api/transaction

        [HttpPost("AddTransaction")]
        public async Task<IActionResult> AddTransaction([FromBody] Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return Ok(transaction);
        }
    }
}
