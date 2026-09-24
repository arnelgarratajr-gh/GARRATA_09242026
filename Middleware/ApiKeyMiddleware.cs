namespace GARRATA_09242026.Middleware;

public class ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
{
    private const string ApiKeyHeaderName = "X-API-Key";
    private const string ApiKeyConfigurationName = "ApiKey";

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/api/FileProcessing/process"))
        {
            var expectedApiKey = configuration[ApiKeyConfigurationName];
            var suppliedApiKey = context.Request.Headers[ApiKeyHeaderName].FirstOrDefault();

            if (string.IsNullOrWhiteSpace(expectedApiKey) ||
                !string.Equals(suppliedApiKey, expectedApiKey, StringComparison.Ordinal))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("A valid API key is required.");
                return;
            }
        }

        await next(context);
    }
}
