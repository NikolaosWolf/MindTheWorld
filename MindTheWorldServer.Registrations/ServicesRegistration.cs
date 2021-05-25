using Microsoft.Extensions.DependencyInjection;
using MindTheWorldServer.Services.Definitions;
using MindTheWorldServer.Services.Implementations;

namespace MindTheWorldServer.Registrations
{
    public static class ServicesRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IEconomyService, EconomyService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IEnergyService, EnergyService>();
            services.AddScoped<IEnviromentService, EnviromentService>();
            services.AddScoped<IHealthService, HealthService>();
            services.AddScoped<IInfrastructureService, InfrastructureService>();
            services.AddScoped<IPopulationService, PopulationService>();
            services.AddScoped<ISocietyService, SocietyService>();
            services.AddScoped<ITransformService, TransformService>();

            return services;
        }
    }
}
