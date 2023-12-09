using Microsoft.Extensions.DependencyInjection;

namespace Dace23Demo.Implementation.Startup
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var builder = new ServicesBuilder(services);

            builder
                .AddServices()
                .AddScreens()
                .AddApplication();

            return services;
        }
    }
}