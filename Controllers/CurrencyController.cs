using FinanceTracker.Data;
using FinanceTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CurrencyController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/currency
        [HttpGet]
        public async Task<IActionResult> GetCurrencies()
        {
            var currencies = await _context.Currencies.ToListAsync();
            return Ok(currencies);
        }

        // POST: api/currency
        [HttpPost]
        public async Task<IActionResult> AddCurrency([FromBody] Currency currency)
        {
            _context.Currencies.Add(currency);
            await _context.SaveChangesAsync();
            return Ok(currency);
        }
    }
}
