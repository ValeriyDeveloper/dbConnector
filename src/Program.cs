using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PSqlConnection")));

builder.Services.AddScoped<AutoMigrator>();

var app = builder.Build();

var scopeService = app.Services.CreateScope();
await (scopeService.ServiceProvider.GetRequiredService<AutoMigrator>()).Run();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<GreeterService>();
});

app.Run();