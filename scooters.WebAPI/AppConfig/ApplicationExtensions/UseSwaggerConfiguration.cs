using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace scooters.WebAPI.AppConfig.ApplicationExtensions
{
    
    public static partial class ApplicationExtensions
    {
        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName);
                };
            });
        }
    }
}