using Microsoft.Extensions.DependencyInjection;
using MindTheWorldServer.Services.Definitions;
using MindTheWorldServer.Services.Implementations;

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
