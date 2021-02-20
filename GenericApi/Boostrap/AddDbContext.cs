using GenericApi.Model;
using GenericAPI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace API.Boostrap
{
    public static class AddDbContextExtension
    {
        public static void AddDbContextService(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<GenericApiContext>(b => b
                    .UseSqlServer(configuration.Get<Settings>().ConnectionStrings.GenericApiContext));

            //serviceCollection.AddScoped<GenericApiContext>(sp => sp.GetService<GenericApiContext>());
        }
    }
}
