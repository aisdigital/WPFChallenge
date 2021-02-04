using Microsoft.Extensions.DependencyInjection;
using MySchool.Infra.Data.Repositories.Context;
using MyStockSys.Domain.Handlers;
using WpfChallenge.Data.Infra.Repositories;
using WpfChallenge.Data.Infra.Repositories.Transactions;
using WpfChallenge.Domain.Interfaces;
using WpfChallenge.Domain.Queries;

namespace WpfChallenge.Data.IoC
{
    public static class NativeInjectorBootStrapper
    {
        //// Domain - Commands
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain - Commands
            services.AddTransient<CustomerQueries>();

            //// Domain - Handlers
            services.AddTransient<CustomerHandler, CustomerHandler>();

            //// Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<WpfChallengeContext>();
        }
    }
}
