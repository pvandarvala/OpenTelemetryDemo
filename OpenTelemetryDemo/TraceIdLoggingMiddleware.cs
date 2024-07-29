using System.Diagnostics;

namespace OpenTelemetryDemo
{
    public class TraceIdLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public TraceIdLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger<TraceIdLoggingMiddleware> logger)
        {
            var activity = Activity.Current;
            if (activity != null)
            {
                using (logger.BeginScope(new Dictionary<string, object>
                {
                    ["TraceId"] = activity.TraceId.ToString(),
                    ["SpanId"] = activity.SpanId.ToString()
                }))
                {
                    await _next(context);
                }
            }
            else
            {
                await _next(context);
            }
        }
    }

    public static class TraceIdLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseTraceIdLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TraceIdLoggingMiddleware>();
        }
    }


}
