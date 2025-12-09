using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Behaviours;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace BuberDinner.Application
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
           services.AddMediatR(typeof(DependencyInjection).Assembly);

            services.AddScoped<
                IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>,
                ValidationRegisterCommandBehaviour>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
