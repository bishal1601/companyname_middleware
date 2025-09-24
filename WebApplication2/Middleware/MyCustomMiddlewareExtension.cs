namespace WebApplication2.Middleware;

public static class MyCustomMiddlewareExtension
{
    public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyCustomMiddleware>();
    }
    
}