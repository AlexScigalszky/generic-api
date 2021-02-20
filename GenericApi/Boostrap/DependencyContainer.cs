
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GenericAPI.Boostrap
{
    public static class DependencyContainer
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Add AutoMapper
            //services.AddAutoMapper(typeof(Startup));

            // Add Core Layer
            services.Configure<Settings>(configuration);

            // Add Infrastructure Layer
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            
        }
    }
}
