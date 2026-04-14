

using MediatR;
using MySolution.Application.Command.Clients.Dtos;
using MySolution.Application.Common.Exceptions;
using MySolution.Application.Queries.Clients;
using MySolution.Domain.Clients;
namespace MySolution.Application.Queries.Clients;
public class GetClientByIdHandler(IClientRepository clientRepository) : IRequestHandler<GetClientByIdQuery, ClientDto>
{
    public async Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        var client = await clientRepository.GetClient(request.clientId);
        if(client==null)
        {
            throw new NotFoundException("Client not found");
        }

        return new ClientDto(client.Name,client.ClientID,client.DateSub);
    }
}