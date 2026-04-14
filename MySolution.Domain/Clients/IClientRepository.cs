namespace MySolution.Domain.Clients;
public interface IClientRepository
{
      Task<Client> AddClient(Client client);
      Task<Client?>GetClient(int clientId);
      Task<List<Client>> GetAllClients();
}