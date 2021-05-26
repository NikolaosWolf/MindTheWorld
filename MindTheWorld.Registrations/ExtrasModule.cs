using Microsoft.Extensions.DependencyInjection;
using MindTheWorld.Extras.Helpers;

namespace MindTheWorld.Registrations
{
    public static class ExtrasModule
    {
        public static IServiceCollection RegisterExtras(this IServiceCollection services)
        {
            services.AddScoped<ICsvTransformer, CsvTransformer>();

            return services;
        }
    }
}
