using MediatR;
using MySolution.Application.Command.Clients.Dtos;
using MySolution.Domain.Clients;

public record GetAllClientQuery():IRequest<List<ClientDto>>{};