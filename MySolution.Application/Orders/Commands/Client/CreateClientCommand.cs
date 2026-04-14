using MediatR;
using MySolution.Domain.Clients;
namespace MySolution.Application.Command.Clients;
public record CreateClientCommand(string name,DateTime datesub):IRequest<Client>;