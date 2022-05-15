namespace API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILoggerFactory _loggerFactory;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _loggerFactory = loggerFactory;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var logger = _loggerFactory.CreateLogger<ExceptionHandlingMiddleware>();
        
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex,
                "Exception type {exType}, message: {exMessage}, source: {exSource}, stacktrace: {exStackTrace}",
                ex.GetType(), ex.Message, ex.Source, ex.StackTrace);

            await context.Response.WriteAsJsonAsync(new { errorMessage = ex.Message });
        }
    }
}
