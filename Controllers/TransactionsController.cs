using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerBalancePlatform.Data;
using CustomerBalancePlatform.Models;

[Route("api/[controller]")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TransactionsController(AppDbContext context)
    {
        _context = context;
    }

    // POST: api/Transactions
    [HttpPost]
    public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
    {
        var customer = await _context.Customers.FindAsync(transaction.CustomerId);
        if (customer == null)
        {
            return NotFound(new { message = "Customer not found" });
        }

        _context.Transactions.Add(transaction);

        if (transaction.Type == TransactionType.Invoice)
        {
            customer.CurrentBalance += transaction.Amount;
        }
        else if (transaction.Type == TransactionType.Payment)
        {
            customer.CurrentBalance -= transaction.Amount;
        }

        await _context.SaveChangesAsync();
        return CreatedAtAction("GetTransaction", new { id = transaction.Id }, transaction);
    }

    // GET: api/Transactions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
    {
        var transactions = await _context.Transactions
            .Where(t => (startDate == null || t.Date >= startDate) && (endDate == null || t.Date <= endDate))
            .Include(t => t.Customer)
            .ToListAsync();
       return transactions;
   }

   // GET: api/Transactions/{customerId}
   [HttpGet("{customerId}")]
   public async Task<ActionResult<IEnumerable<Transaction>>> GetCustomerTransactions(int customerId, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
   {
       var transactions = await _context.Transactions
           .Where(t => t.CustomerId == customerId && (startDate == null || t.Date >= startDate) && (endDate == null || t.Date <= endDate))
           .Include(t => t.Customer)
           .ToListAsync();

       if (!transactions.Any())
       {
           return NotFound(new { message = "No transactions found for this customer" });
       }

       return transactions;
   }
}
