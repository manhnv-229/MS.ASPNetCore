var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.Use(async (context, next) => {
    await context.Response.WriteAsync("Before Invoke from 1st app.Use()\n");
    await next.Invoke();
    await context.Response.WriteAsync("After Invoke from 1st app.Use()\n");
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Before Invoke from 2nd app.Use()\n");
    await next();
    await context.Response.WriteAsync("After Invoke from 2nd app.Use()\n");
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello from 1st app.Run()\n");
});

// Đoạn mã lệnh này sẽ không bao giờ được thực thi.
// the following will never be executed 
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello from 2nd app.Run()\n");
});

app.Run();
