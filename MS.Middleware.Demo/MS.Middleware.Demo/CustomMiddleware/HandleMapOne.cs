namespace MS.Middleware.Demo.CustomMiddleware
{
    public class HandleMapOne
    {
        private RequestDelegate _next;

        public HandleMapOne(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("MapOne!");
            await _next(context);
        }
    }
}
