namespace MySolution.Domain.Clients;
public class Client
{
    public string Name { get; set; }
    public int ClientID { get; set; }   
    public DateTime DateSub { get; set; }
    private Client(){}
    public Client(string name,DateTime datesub)
    {
        Name = name;
        DateSub = datesub;
    }
}