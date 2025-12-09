using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
           services.AddMediatR(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}
