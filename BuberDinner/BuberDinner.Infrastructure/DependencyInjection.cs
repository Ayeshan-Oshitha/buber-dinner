using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
        {
            return services;
        }
    }
}
