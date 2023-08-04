namespace MS.Middleware.Demo
{
    public static class HandleMap
    {
        public static void HandleContact(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Contact me at manhnv229@gmail.com");
            });
        }

        public static void HandleAbout(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hi, I'am Manh.");
            });
        }

        public static void HandleWelcome(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Welcome to Manh Software!");
            });
        }
    }
}
