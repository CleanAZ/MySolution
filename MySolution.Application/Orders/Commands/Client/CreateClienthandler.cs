using System.Text.Json;
using MediatR;
using MySolution.Domain.Clients;
using MySolution.Domain.Quemessage;
namespace MySolution.Application.Command.Clients;
public class CreateClientHandler(IClientRepository clientRepository,IQueMessage queMessage) : IRequestHandler<CreateClientCommand, Client>
{
    public async Task<Client> Handle(CreateClientCommand request,CancellationToken token)
    {
        var client = new Client(request.name,DateTime.Now);
       await clientRepository.AddClient(client);
       var message = JsonSerializer.Serialize(new
       {
           client.Name
       });
       await queMessage.sendAsync(message);
        return client;

    }
}