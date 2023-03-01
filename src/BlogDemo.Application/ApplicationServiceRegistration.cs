using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BlogDemo.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.AsScoped(), assembly);

            services.AddAutoMapper(assembly);

            return services;
        }
    }
}
