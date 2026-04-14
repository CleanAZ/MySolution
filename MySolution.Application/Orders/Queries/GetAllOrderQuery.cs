using MediatR;
using MySolution.Application.DTOs;

public record GetAllOrdersQuery():IRequest<List<OrderDto>>;