using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;

namespace BuberDinner.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationService(this IServiceCollection services)
        {

            services.AddSwaggerAuth();

            services.AddControllers();

            services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();

            services.AddMappings();

            return services;
        }

        public static IServiceCollection AddSwaggerAuth(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter your JWT token"
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return services;
        }

    }
}
