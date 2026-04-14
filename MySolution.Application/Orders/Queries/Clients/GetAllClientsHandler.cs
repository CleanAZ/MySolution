using MediatR;
using MySolution.Application.Command.Clients.Dtos;
using MySolution.Domain.Clients;

public class GetAllClientHandler(IClientRepository clientRepository) : IRequestHandler<GetAllClientQuery, List<ClientDto>>
{
    public async Task<List<ClientDto>> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
    {
        List<ClientDto> clientsList=new List<ClientDto>();
        var clients = await clientRepository.GetAllClients();
        clients.ForEach(x =>
        {
            clientsList.Add(new ClientDto(x.Name,x.ClientID,x.DateSub));            
        });

        return clientsList;
    }
}
