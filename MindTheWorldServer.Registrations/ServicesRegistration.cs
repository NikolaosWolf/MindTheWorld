using Microsoft.Extensions.DependencyInjection;
using MindTheWorldServer.Implementation.Services;
using MindTheWorldServer.Services.Definitions;

namespace MindTheWorldServer.Registrations.Services
{
    public static class ServicesRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IEnviromentService, EnviromentService>();

            return services;
        }
    }
}
