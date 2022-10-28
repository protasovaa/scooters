using scooters.WebAPI.AppConfig.ServicesExtensions;
using scooters.WebAPI.AppConfig.ApplicationExtensions;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddSerilogConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddVersioningConfiguration();
builder.Services.AddControllers();

var app = builder.Build();

app.UseSerilogConfiguration();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

try
{
    Log.Information("Application starting...");

    app.Run();
}
catch (Exception ex)
{
    Log.Error("Application finished with error {error}", ex);
}
finally
{
    Log.Information("Application stopped");
    Log.CloseAndFlush();
}