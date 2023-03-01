using BlogDemo.Application.Interfaces;
using BlogDemo.Infrastructure.Data.Contexts;
using BlogDemo.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogDemo.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext, ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BlogDemo.LocalDb"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));

            return services;
        }
    }
}
