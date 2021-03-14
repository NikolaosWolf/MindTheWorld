using Microsoft.Extensions.DependencyInjection;
using MindTheWorldServer.Extras.Helpers;

namespace MindTheWorldServer.Extras
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
