using System.Net;
using MySolution.Application.Common.Exceptions;
namespace MySolution.API.Middleware;
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next=next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception ex)
        {
            await HandleExceptionAsync(context,ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context,Exception exception)
    {
          context.Response.ContentType = "application/json";

        context.Response.StatusCode = exception switch
        {
            NotFoundException => 404,
            ArgumentException => 400,
            _ => 500
        };

        var response = new
        {
            error = exception.Message
        };

        return context.Response.WriteAsJsonAsync(response);
    }
}