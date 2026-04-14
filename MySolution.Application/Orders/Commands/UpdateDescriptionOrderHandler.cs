using MediatR;
using MySolution.Domain.Orders;
namespace MySolution.Application.Command;

public class UpdateDescriptionOrderHandler:IRequestHandler<UpdateDescriptionOrderCommand,string>
{
    private readonly IOrderRepository _orderRepository;
    public UpdateDescriptionOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository=orderRepository;
    }

     public async Task<string> Handle(UpdateDescriptionOrderCommand request,CancellationToken cancellationToken)
    {
        
             await _orderRepository.AddDescription(request.description,request.id);
             return request.description;
        
    }
}