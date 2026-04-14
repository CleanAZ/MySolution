namespace MySolution.Domain.Orders;
public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task<Order?> GetByIdAsync(Guid id);
    Task<Order?> AddDescription(string Description,Guid id);
     Task<List<Order>> GetAllAsync();
}