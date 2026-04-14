using Amazon.SQS;
using Amazon.SQS.Model;
namespace MySolution.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IAmazonSQS _sqs;
    private readonly IConfiguration _config;
    private readonly string _queueUrl;
    public Worker(ILogger<Worker> logger,IAmazonSQS sqs,IConfiguration config)
    {
        _logger = logger;
        _sqs=sqs;
        _config=config;
        _queueUrl = _config["AWS:SQS:QueueUrl"];
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try{
            var response = await _sqs.ReceiveMessageAsync(new ReceiveMessageRequest
            {
                 QueueUrl = _queueUrl,
                  MaxNumberOfMessages=5,
                  WaitTimeSeconds=20
            });
            foreach(var message in response.Messages)
            {Console.WriteLine("Polling SQS...");
                Console.WriteLine($"received:{message.Body}");
                Console.WriteLine($"Messages count: {response.Messages.Count}");
                await _sqs.DeleteMessageAsync(_queueUrl,message.ReceiptHandle);
            }
           
        }
        catch(Exception ex)
            {
                Console.WriteLine("Error");
            } 
            await Task.Delay(2000);
        }
    }
}
