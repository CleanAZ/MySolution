using MySolution.Application.DTOs;
using MediatR;
namespace MySolution.Application.Queries;
public record GetOrderByIdQuery(Guid Id):IRequest<OrderDto>;