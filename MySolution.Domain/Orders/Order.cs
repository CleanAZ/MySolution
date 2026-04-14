namespace MySolution.Domain.Orders;

public class Order
{
    public Guid Id { get; set; }
    public decimal  Total { get; set; }
    public string Description { get; set; }
    public DateTime OrderDate{get;set;}
    public Order(Guid id, decimal total,string description)
    {
        Id = id;
        Total = total;
        Description = description;
        OrderDate = DateTime.Now;
    }
}
