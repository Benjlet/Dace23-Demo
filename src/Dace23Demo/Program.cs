using Dace23Demo.Implementation.Startup;
using Microsoft.Extensions.DependencyInjection;

namespace Dace23Demo
{
    class Program
    {
        public static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddHttpClient()
                .AddApplicationServices()
                .BuildServiceProvider();

            DemoApp demoApp = serviceProvider.GetRequiredService<DemoApp>();

            demoApp.Run();
        }
    }
}