using Serilog;

namespace scooters.WebAPI.AppConfig.ServicesExtensions
{
    public static partial class ServicesExtensions
    {
        public static void AddSerilogConfiguration(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, loggerConfiguration) =>
            {
                loggerConfiguration
                .Enrich.WithCorrelationId()
                .ReadFrom.Configuration(context.Configuration);
            });

            builder.Services.AddHttpContextAccessor();
        }
    }
}