using System;
using Kubernetes.Web.Mystery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGet("/healthz", (HttpContext context) =>
{
    const string HealthVariableName = "HEALTH_STATUS";

    string? health = Environment.GetEnvironmentVariable(HealthVariableName);
    if (string.IsNullOrWhiteSpace(health))
    {
        ILogger logger = context.RequestServices
            .GetRequiredService<ILoggerFactory>()
            .CreateLogger("Kubernetes.Web.Mystery.Health");

        logger.MissingVariable(HealthVariableName);
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status200OK;
    }
});

app.Run();
