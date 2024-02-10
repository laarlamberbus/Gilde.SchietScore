using Gilde.SchietScore.Persistence;
using Gilde.SchietScore.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gilde.SchietScore.CompositionRoot
{
    public static class CompositionAggregate
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            services.AddApplication(configuration);

            return services;
        }
    }
}
