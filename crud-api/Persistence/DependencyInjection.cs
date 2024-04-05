using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ASP.NET_WebApi.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(
                config.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)
            ));


            return services;
        }
    }
}
