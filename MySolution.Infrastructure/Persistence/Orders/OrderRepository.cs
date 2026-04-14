using Microsoft.EntityFrameworkCore;
using MySolution.Domain.Orders;
namespace MySolution.Infrastructure.Orders;
public class OrderRepository:IOrderRepository
{
    private readonly AppDbContext _context;
    public OrderRepository(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders.ToListAsync<Order>();
    }
    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task<Order?> AddDescription(string description,Guid id)
    {

Console.WriteLine(id);
      var order = await _context.Orders.FindAsync(id);
      if(order==null)
      return null;
      
      order.Description = description;
      
       await _context.SaveChangesAsync();
       return order;
    }
}