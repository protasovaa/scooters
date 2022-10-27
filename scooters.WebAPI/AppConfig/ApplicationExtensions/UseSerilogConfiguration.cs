using Serilog;

namespace scooters.WebAPI.AppConfig.ApplicationExtensions
{
    public static partial class ApplicationExtensions
    {
        public static void UseSerilogConfiguration(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging();
        }
    }
}