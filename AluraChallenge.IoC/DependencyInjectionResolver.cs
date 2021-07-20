using AluraChallenge.Domain.Interfaces.Repositories;
using AluraChallenge.Domain.Interfaces.Services;
using AluraChallenge.Domain.Services;
using AluraChallenge.Infra.Persistence.Repositories;
using AluraChallenge.Infra.Transactions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AluraChallenge.IoC
{
    public static class DependencyInjectionResolver
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IServiceVideo, ServiceVideo>();
            services.AddScoped<IRepositoryVideo, RepositoryVideo>();
        }
    }
}
