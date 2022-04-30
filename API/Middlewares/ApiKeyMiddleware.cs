namespace UI.Middlewares;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;
    private const string ApiKeyName = "api_key";
    
    public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        context.Request.Headers.TryGetValue(ApiKeyName, out var extractedApiKey);
        var apiKey = _configuration.GetValue<string>(ApiKeyName);
 
        if (!apiKey.Equals(extractedApiKey))
        {
            context.Response.StatusCode = 403;
            return;
        }
 
        await _next(context);
    }
}
