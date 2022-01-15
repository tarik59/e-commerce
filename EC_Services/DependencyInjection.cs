using Application.Services;
using EC_Services.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EC_Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceContainer
        (this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
