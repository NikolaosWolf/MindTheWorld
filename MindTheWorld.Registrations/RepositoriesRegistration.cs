using Microsoft.Extensions.DependencyInjection;
using MindTheWorld.Infrastructure.Definitions;
using MindTheWorld.Infrastructure.Repositories;

namespace MindTheWorld.Registrations
{
    public static class RepositoriesRegistration
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICountryRepository, CountryRepository>();

            return services;
        }
    }
}
