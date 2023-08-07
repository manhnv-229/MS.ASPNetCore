using System.Net;
using System.Text.Json;

namespace MS.JWT.Demo.Middleware
{
    public class ExceptionHandleMiddleware
    {
        private RequestDelegate _next;

        public ExceptionHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var res = new
                {
                    status = HttpStatusCode.InternalServerError,
                    message = ex.Message,

                };
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType= "application/json";
                var json = JsonSerializer.Serialize(res);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
