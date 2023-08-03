namespace MS.Middleware.Demo
{
    public static class HandleMap
    {
        public static void HandleContact(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Contact us at reach.rsmrocks@gmail.com");
            });
        }

        public static void HandleAbout(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hi from rsmrocks");
            });
        }

        public static void HandleWelcome(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Welcome to our Blog");
            });
        }
    }
}
