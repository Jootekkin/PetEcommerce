using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PetEcommerce.Core.Behavior;
using PetEcommerce.Core.Mapping;
using System.Reflection;

namespace PetEcommerce.Core
{
    public static class CoreDependencyInjection
    {
        public static IServiceCollection AddCoreDependencyInjection(this IServiceCollection services)
        {
            // Add MediatR for CQRS
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CoreDependencyInjection).Assembly);
                cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
            });
            // Add Fluentvalidation 
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // Add AutoMapper for object mapping
            services.AddAutoMapper(cfg => cfg.AddProfile(typeof(Profiling)));
            return services;
        }
    }
}
