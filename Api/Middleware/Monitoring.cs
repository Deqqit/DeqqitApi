using Prometheus;

namespace Api.Middleware;

public class MonitoringMiddleware
{
    private readonly RequestDelegate _next;

    private static readonly Counter RequestCounter =
        Metrics.CreateCounter(
            "prometheus_demo_request_total",
            "Total HTTP requests",
            new CounterConfiguration
            {
                LabelNames = ["path", "method", "status"]
            });

    public MonitoringMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value ?? string.Empty;
        var method = context.Request.Method;

        try
        {
            await _next(context);
        }
        finally
        {
            if (path != "/metrics")
            {
                RequestCounter
                    .Labels(path, method, context.Response.StatusCode.ToString())
                    .Inc();
            }
        }
    }
}