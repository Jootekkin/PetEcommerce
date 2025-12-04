using Microsoft.Extensions.DependencyInjection;
using PetEcommerce.Service.BaseService;

namespace PetEcommerce.Service
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection AddServiceDependencyInjection(this IServiceCollection services)
        {
            // Register service layer dependencies here
            // e.g., services.AddScoped<IYourService, YourServiceImplementation>();
            services.Scan(scan => scan
                .FromAssemblyOf<PetService>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }
    }
}
