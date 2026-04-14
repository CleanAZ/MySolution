using MediatR;
using MySolution.Application.DTOs;
using MySolution.Domain.Orders;
namespace MySolution.Application.Command;
public class CreateOrderHandler(IOrderRepository orderRepository):IRequestHandler<CreateOrderCommand,OrderDto>
{
   
   public async Task<OrderDto>  Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order(Guid.NewGuid(),request.Total,request.description);
        order.OrderDate=DateTime.Now;
        await orderRepository.AddAsync(order);
        return new OrderDto(order.Id, order.Total, order.Description,order.OrderDate);
    }
}
