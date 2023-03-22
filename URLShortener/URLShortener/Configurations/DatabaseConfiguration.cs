using Microsoft.EntityFrameworkCore;
using URLShortener.Database;
using URLShortener.Database.Identity;

namespace URLShortener.Configurations
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<URLDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("URLDatabase")));

            services.AddDbContext<IdentityURLDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityURLDatabase")));

            return services;
        }
    }
}
