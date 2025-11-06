using FinanceTracker.Data;
using FinanceTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionTypeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransactionTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/transactiontype
        [HttpGet]
        public async Task<IActionResult> GetTransactionTypes()
        {
            var types = await _context.TransactionTypes.ToListAsync();
            return Ok(types);
        }

        // POST: api/transactiontype
        [HttpPost]
        public async Task<IActionResult> AddTransactionType([FromBody] TransactionType type)
        {
            _context.TransactionTypes.Add(type);
            await _context.SaveChangesAsync();
            return Ok(type);
        }
    }
}
