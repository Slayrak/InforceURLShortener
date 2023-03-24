using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using URLShortener.Database;
using URLShortener.Database.Identity;
using URLShortener.Domain.Models;

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

        public static async Task<IHost> MigrateDatabaseAsync(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<URLDbContext>())
                {
                    using(var identityContext = scope.ServiceProvider.GetRequiredService<IdentityURLDbContext>())
                    {
                        try
                        {
                            var dataseed = new DataSeed(scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>(),
                                scope.ServiceProvider.GetRequiredService<RoleManager<AppUserRoles>>());

                            dataseed.SeedData(context, identityContext).Wait();
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                    
                }
            }
            return host;
        }
    }
}
