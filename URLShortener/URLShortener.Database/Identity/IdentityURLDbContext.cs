using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Domain.Models;

namespace URLShortener.Database.Identity
{
    public class IdentityURLDbContext : IdentityDbContext<AppUser>
    {
        public IdentityURLDbContext(DbContextOptions<IdentityURLDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
    }
}
