using MediatR;
using MySolution.Application.Command.Clients.Dtos;

namespace MySolution.Application.Queries.Clients;
public record GetClientByIdQuery(int clientId):IRequest<ClientDto>;