using Application.Mediatr.Command;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationContainer
            (this IServiceCollection services, IConfiguration config)
        {
            services.AddMediatR(typeof(CreateOrderHandler).Assembly);
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            return services;
        }
    }
}
