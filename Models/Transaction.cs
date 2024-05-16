namespace CustomerBalancePlatform.Models
{
public class Transaction
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string UniqueNumber { get; set; } = string.Empty;
    public string Remarks { get; set; } = string.Empty;
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;  // Null-forgiving operator if initialization is not possible
}
}
