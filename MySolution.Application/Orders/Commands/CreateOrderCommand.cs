using MediatR;
using MySolution.Application.DTOs;
namespace MySolution.Application.Command;
public record CreateOrderCommand(decimal Total,string description):IRequest<OrderDto>;