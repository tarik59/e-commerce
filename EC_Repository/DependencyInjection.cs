using Application.Repositories;
using EC_Repository.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EC_Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryContainer
            (this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}
