using MediatR;
using Microsoft.AspNetCore.Mvc;
using MySolution.Application.Queries;
using MySolution.Application.Command;
using MySolution.Application.DTOs;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Authorization;
namespace MySolution.API.Controllers.Orders;
[ApiController]
[Route("api/orders")]
public class OrdersController:ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator=mediator;
    }

[HttpPost]
public async Task<IActionResult> AddOrder([FromBody] OrderDto orderDto)
    {
        var result = await _mediator.Send(new CreateOrderCommand(orderDto.Total,orderDto.Description));
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult>Get(Guid id)
    {
        var result = await _mediator.Send(new GetOrderByIdQuery(id));
        return Ok(result);

    }

   [HttpPut("{id}/description")]
    public async Task<IActionResult> Post([FromBody]string description,Guid id)
    {
        var result = await _mediator.Send(new UpdateDescriptionOrderCommand(description,id));
        return Ok(result);
    }

    [Authorize]
    [HttpGet]
    public async Task<List<OrderDto>>GetAll()
    {
        var result = await _mediator.Send(new GetAllOrdersQuery());
        return result;

    }
}