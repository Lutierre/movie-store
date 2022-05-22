using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public static class ServicesConfiguration
{
    public static void AddDalServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MovieStoreContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(MovieStoreContext).Assembly.FullName)));
        
        services.AddScoped<UnitOfWork>();
    }
}
