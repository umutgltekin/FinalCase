using Serilog;
using System.Text.Json;

namespace Vk.Api.Midleware
{
    public class HartBeatMiddleware
    {
        private readonly RequestDelegate _next;
        public HartBeatMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext context)
        {
            Log.Information("HeartBead");
            if (context.Request.Path.StartsWithSegments("/Hello"))
            {

                await context.Response.WriteAsync(JsonSerializer.Serialize("Hello from server"));
                context.Response.StatusCode = 202;
                return;
            }
            await _next.Invoke(context);
        }
    }
}
