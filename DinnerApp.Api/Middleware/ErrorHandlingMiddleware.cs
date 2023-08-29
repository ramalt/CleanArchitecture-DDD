using System.Net;
using System.Text.Json;

namespace DinnerApp.Api.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExeptionAsync(context, ex);
        }
    }

    private Task HandleExeptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        context.Response.StatusCode = (int)code;
        context.Response.ContentType = "application/json";
        var result = JsonSerializer.Serialize(new { error = exception.Message });


        return context.Response.WriteAsync(result);
    }
}
