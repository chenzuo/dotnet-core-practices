using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication5.Infrastructure.Impl;
using WebApplication5.Infrastructure.Interfaces;

namespace WebApplication5.Infrastructure.Service
{
    public  static class InfrastructureModule
    {
        public static IServiceCollection AddInfraService(this IServiceCollection services)
        {
            services.AddTransient<IJwtFactory, JwtFactory>();
            services.AddTransient<IJwtTokenHandler, JwtTokenHandler>();
            services.AddTransient<ITokenFactory, TokenFactory>();
            services.AddTransient<IJwtTokenValidator, JwtTokenValidator>();
            return services;
        }
    }
}
