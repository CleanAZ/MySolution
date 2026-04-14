using MySolution.Application.DTOs;
using MySolution.Domain.Orders;
using MySolution.Application.Common.Exceptions;
using MediatR;
namespace MySolution.Application.Queries;
public class GetOrderByIdHandler:IRequestHandler<GetOrderByIdQuery,OrderDto>
{
    private readonly IOrderRepository _orderRepository;
    public GetOrderByIdHandler(IOrderRepository repository)
    {
        _orderRepository=repository;
    }
    public async Task<OrderDto> Handle(GetOrderByIdQuery request,CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id);
        if(order == null)
        {
            throw new NotFoundException("Order not found");
        }

        return new OrderDto(order.Id,order.Total,order.Description,order.OrderDate);
    } 
}