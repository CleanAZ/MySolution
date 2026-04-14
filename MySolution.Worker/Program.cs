using MySolution.Worker;
using Amazon.SQS;
using Amazon.Extensions.NETCore.Setup;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonSQS>();
var host = builder.Build();
host.Run();
