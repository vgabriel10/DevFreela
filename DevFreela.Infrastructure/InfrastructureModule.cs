using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.AuthServices;
using DevFreela.Infrastructure.Payments;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using DevFreela.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DevFreela.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddServices()
                .AddRepositories()
                .AddData(configuration)
                .AddAutentication()
                .AddHttpClients();
            
            return services;
        }

        private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DevFreelaCs");
            services.AddDbContext<DevFreelaDbContext>(o => o.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPaymentlService, PaymentService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository,ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            return services;
        }

        public static IServiceCollection AddAutentication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }

        public static IServiceCollection AddHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient();
            return services;
        }
    }
}
