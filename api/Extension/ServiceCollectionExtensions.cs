using RaizenUserRegister.Application.Services;
using RaizenUserRegister.Domain.Interface;
using RaizenUserRegister.Infra.Data.Repository;

namespace RaizenUserRegister.Application.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRegisterService, UserRegisterService>();
            return services;
        }
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
        public static IServiceCollection AddHttpClientFactory(this IServiceCollection services)
        {
            services.AddHttpClient<IAddressClientService, AddressClientService>();
            services.AddScoped<IAddressClientService, AddressClientService>();

            return services;
        }
    }
}
