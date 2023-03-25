using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using URLShortener.Domain.Models;
using URLShortener.Configurations;
using URLShortener.Database.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using URLShortener.Domain.Interfaces.Repositories;
using URLShortener.Database.Repositories;
using URLShortener.Domain.Interfaces.Services;
using URLShortener.Business.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddIdentity<AppUser, AppUserRoles>().AddEntityFrameworkStores<IdentityURLDbContext>();

builder.Services.AddScoped<IURLRepository, URLRepository>();

builder.Services.AddScoped<IURLService, URLService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCrossOriginResourceSharing();
app.UseAuthentication();
app.UseAuthorization();

await app.MigrateDatabaseAsync();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
