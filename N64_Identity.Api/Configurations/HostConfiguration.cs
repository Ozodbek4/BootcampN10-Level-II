namespace N64_Identity.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder) =>
        new ValueTask<WebApplicationBuilder> (builder
            .AddIdentityInfrastructure()
            .AddDevTools()
            .AddExposers());

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app) =>
        new ValueTask<WebApplication>(app
            .UseIdnetityInfrastructure()
            .UseDevTools()
            .UseExposers());
}