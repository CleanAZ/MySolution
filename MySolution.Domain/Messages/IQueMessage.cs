namespace MySolution.Domain.Quemessage;
public interface IQueMessage
{
    Task sendAsync(string message);
}