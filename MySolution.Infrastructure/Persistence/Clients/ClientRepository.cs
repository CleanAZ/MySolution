using Microsoft.EntityFrameworkCore;
using MySolution.Domain.Clients;
using MySolution.Infrastructure;
namespace MySolution.Infrastructure.Clients;
public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;
    public ClientRepository(AppDbContext context)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<Client> AddClient(Client client)
    {
        var newclient = new Client(client.Name,client.DateSub);
        await _context.Clients.AddAsync(newclient);
        await _context.SaveChangesAsync();
        return newclient;
    }

    public async Task<List<Client>> GetAllClients()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client?> GetClient(int clientId)
    {
        Client? client = await _context.Clients.FirstOrDefaultAsync(x=>x.ClientID==clientId);
        return client;
    }
}