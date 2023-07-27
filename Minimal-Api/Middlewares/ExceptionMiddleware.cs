using Minimal_Api.Services.Exception;

namespace Minimal_Api.ExceptionMiddleware;

public class ExceptionMiddleware : ServiceException
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
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
            if (ex.GetType().BaseType == typeof(ServiceException))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync( ex.Message);
            }
        }
    }

}