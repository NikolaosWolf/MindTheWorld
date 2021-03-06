using Microsoft.Extensions.DependencyInjection;
using MindTheWorldServer.Implementation.Services;
using MindTheWorldServer.Infrastructure.Services;

namespace MindTheWorldServer.Implementation
{
    public static class ImplementationModule
    {
        public static IServiceCollection RegisterImplementationServices(this IServiceCollection services)
        {
            services.AddScoped<IEnviromentService, EnviromentService>();

            return services;
        }
    }
}
