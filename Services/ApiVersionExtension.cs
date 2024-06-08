using Asp.Versioning;

namespace demo01.services;

public static class ApiVersionExtension
{
    public static IServiceCollection AddApiVersionService(this IServiceCollection services)
    {
        services.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new(2, 1);
            config.ReportApiVersions = true;
            config.AssumeDefaultVersionWhenUnspecified = false;
            config.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader("api-version"),
                new HeaderApiVersionReader("api-x-version")
            );
        }).AddApiExplorer(config =>
        {
            config.GroupNameFormat = "v'V'";
            config.SubstituteApiVersionInUrl = true;
        });
        return services;
    }
}