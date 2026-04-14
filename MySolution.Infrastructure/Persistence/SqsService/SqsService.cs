namespace MySolution.Domain.SQS;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Configuration;
using MySolution.Domain.Quemessage;

public class SqsService : IQueMessage
{
    private readonly IAmazonSQS _sqs;
    private readonly string _urlSQS;
    public SqsService(IAmazonSQS amazonSQS,IConfiguration configuration)
    {
        _sqs = amazonSQS;
        _urlSQS = "https://sqs.us-east-1.amazonaws.com/061051257454/DevQueue";
        
    }
    public async Task sendAsync(string message)
    {Console.WriteLine(_urlSQS);
     Console.WriteLine("Sending message to SQS..."); 
        await _sqs.SendMessageAsync(new SendMessageRequest
        {
            MessageBody = message,
            QueueUrl = _urlSQS 
        });Console.WriteLine("Message sent!");
    }
}
