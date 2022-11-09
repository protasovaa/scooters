using scooters.WebAPI.AppConfig.ServicesExtensions;
using scooters.WebAPI.AppConfig.ApplicationExtensions;
using scooters.WebAPI.AppConfiguration.ServicesExtensions;
using scooters.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;
using scooters.Repository;


var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: false)
.Build();

var builder = WebApplication.CreateBuilder(args);
builder.AddSerilogConfiguration();
builder.Services.AddDbContextConfiguration(configuration);
builder.Services.AddVersioningConfiguration();
builder.Services.AddControllers();
builder.Services.AddSwaggerConfiguration();

//temporary
builder.Services.AddScoped<DbContext, Context>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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
