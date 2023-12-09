using Dace23Demo.Abstractions;
using Dace23Demo.Implementation.Screens;
using Dace23Demo.Implementation.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Dace23Demo.Implementation.Startup
{
    public class ServicesBuilder
    {
        private readonly IServiceCollection _services;

        public ServicesBuilder(IServiceCollection services)
        {
            _services = services;
        }

        public ServicesBuilder AddScreens()
        {
            _services.AddTransient<ICocktailScreen, CocktailScreen>();
            _services.AddTransient<IUserScreen, UserScreen>();

            return this;
        }

        public ServicesBuilder AddServices()
        {
            _services.AddTransient<IHttpClientWrapper, HttpClientWrapper>();
            _services.AddTransient<IDrinkClient, DrinkClient>();
            _services.AddTransient<IUserClient, UserClient>();

            return this;
        }

        public ServicesBuilder AddApplication()
        {
            _services.AddTransient<DemoApp>();

            return this;
        }
    }
}