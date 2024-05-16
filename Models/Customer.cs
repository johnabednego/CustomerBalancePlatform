namespace CustomerBalancePlatform.Models
{
    public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;  // Initialize to avoid nullable warning
    public string Description { get; set; } = string.Empty;
    public string ContactInformation { get; set; } = string.Empty;
    public decimal CurrentBalance { get; set; }
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
}

}
