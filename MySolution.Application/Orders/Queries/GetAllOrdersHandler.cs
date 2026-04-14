using MediatR;
using MySolution.Application.DTOs;
using MySolution.Domain.Orders;

public class GetAllOrdersHandler(IOrderRepository orderRepository) : IRequestHandler<GetAllOrdersQuery,List<OrderDto>>
{
    

    public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var listOrder = await orderRepository.GetAllAsync();
        List<OrderDto> orders = new List<OrderDto>();
        listOrder.ForEach(x=>orders.Add(new OrderDto(x.Id,x.Total,x.Description,x.OrderDate)));
        return orders;
    }
}