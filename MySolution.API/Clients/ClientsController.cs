using MediatR;
using Microsoft.AspNetCore.Mvc;
using MySolution.Application.Command.Clients;
using MySolution.Application.Command.Clients.Dtos;
using MySolution.Application.Queries.Clients;

[ApiController]
[Route("api/[controller]")]
public class ClientsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClientDto dto)
    {
        var result = await mediator.Send(new CreateClientCommand(dto.name,dto.dateSub));
        return Ok(result); 
    }

    [HttpGet("Id")]
    public async Task<IActionResult> GetClient(int clientId)
    {
        var result = await mediator.Send(new GetClientByIdQuery(clientId));
        return Ok(result);
    }

    [HttpGet]
    public async Task<List<ClientDto>> GetAllClients()
    {
        var result = await mediator.Send(new GetAllClientQuery());
        return result;
    }
}

