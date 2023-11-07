using InsuranceApp.Application.Interfaces;
using InsuranceApp.Infrastructure.Persistence;
using InsuranceApp.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InsuranceContext>(options => options.UseInMemoryDatabase("InsuranceInMemoryDB"));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IClaimRepository, ClaimRepository>();
            services.AddScoped<IPolicyHolderRepository, PolicyHolderRepository>();
            return services;
        }
    }
}
