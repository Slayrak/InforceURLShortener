using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Database.Identity;
using URLShortener.Domain.Enums;
using URLShortener.Domain.Models;

namespace URLShortener.Database
{
    public class DataSeed
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppUserRoles> _roleManager;
        public DataSeed(UserManager<AppUser> userManger, RoleManager<AppUserRoles> roleManager)
        {
            _userManager = userManger;
            _roleManager = roleManager;
        }
        public async Task SeedData(URLDbContext uRLDbContext, IdentityURLDbContext identityURLDbContext)
        {
            string[] roleNames = { "Admin", "Visitor" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                {
                    roleResult = await _roleManager.CreateAsync(new AppUserRoles() { Name = roleName });
                }
            }

            if (!identityURLDbContext.Users.Any())
            {
                var userToAdd = new AppUser
                {
                    UserName = $"BigAdmin",
                    Email = $"exampleEmail1@service.domain",
                };

                var result = await _userManager.CreateAsync(userToAdd, "Secret123$");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(userToAdd, Enum.GetName(typeof(UserRole), UserRole.Admin));
                }

                userToAdd = new AppUser
                {
                    UserName = $"SmolUser",
                    Email = $"exampleEmail2@service.domain",
                };

                result = await _userManager.CreateAsync(userToAdd, "NotSecret123$");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(userToAdd, Enum.GetName(typeof(UserRole), UserRole.Visitor));
                }

                await identityURLDbContext.SaveChangesAsync();
            }

            if (!uRLDbContext.Urls.Any())
            {
                int counter = 0;

                foreach (var item in identityURLDbContext.Users)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        await uRLDbContext.Urls.AddAsync(new URLModel
                        {
                            CreationDate = DateTime.UtcNow,
                            ShortedUrl = "check",
                            CreatorId = item.Id.ToString(),
                            Url = $"check{counter}",
                        });

                        counter++;
                    }
                    
                }

                await uRLDbContext.About.AddAsync(new About { Content = "Lorem Ipsum" });
            }

            await uRLDbContext.SaveChangesAsync();
        }

    }
}
