using Microsoft.Extensions.DependencyInjection;
using MindTheWorldServer.Infrastructure.Definitions;
using MindTheWorldServer.Infrastructure.Repositories;

namespace MindTheWorldServer.Registrations
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
