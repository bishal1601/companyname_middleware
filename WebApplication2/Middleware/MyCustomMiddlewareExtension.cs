namespace WebApplication2.Middleware;

public static class UseMyCustomMiddlewareExtension
{
    public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyCustomMiddleware>();
    }
    
}