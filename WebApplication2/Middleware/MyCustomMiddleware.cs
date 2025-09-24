using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
namespace WebApplication2.Middleware;

public class MyCustomMiddleware
{
    private readonly RequestDelegate _next;

    public MyCustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine("Before handling request :" + context.Request.Path);

        // Call the next middleware in the pipeline
        await _next(context);
        
        Console.WriteLine("After handling request :" + context.Response.StatusCode);
    }
}