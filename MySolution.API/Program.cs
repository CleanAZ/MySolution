using Amazon.SQS;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MySolution.Domain.SQS;
using System.Text;
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
var password = "SqlServer@166";//Environment.GetEnvironmentVariable("DB_PASSWORD");
var jwtSettings  = builder.Configuration.GetSection("Jwt");
var key = builder.Configuration["Jwt:Key"];


builder.Services.AddAuthentication("Bearer")
.AddJwtBearer("Bearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes( key))
    };
});
builder.Services.AddAuthorization();
builder.Services.AddInfrastructure(builder.Configuration,password);

/*builder.Services.AddDbContext<MySolution.Infrastructure.AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")+$"Password={password}"));*/
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(MySolution.Application.Command.CreateOrderCommand).Assembly));
    builder.Services.AddScoped<MySolution.Domain.Orders.IOrderRepository,MySolution.Infrastructure.Orders.OrderRepository>();
    builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(MySolution.Application.Command.Clients.CreateClientCommand).Assembly));
    builder.Services.AddScoped<MySolution.Domain.Clients.IClientRepository,MySolution.Infrastructure.Clients.ClientRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("react",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
builder.Services.AddAWSService<IAmazonSQS>();
builder.Services.AddScoped<MySolution.Domain.Quemessage.IQueMessage, SqsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMiddleware<MySolution.API.Middleware.ExceptionHandlingMiddleware>();
    
    
   app.UseCors("react");
    app.UseAuthentication();
    
app.UseAuthorization();
} app.MapControllers();
app.UseSwagger();
    app.UseSwaggerUI();
app.UseHttpsRedirection();


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
