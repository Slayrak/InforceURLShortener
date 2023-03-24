using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Domain.Models;

namespace URLShortener.Database
{
    public class URLDbContext : DbContext
    {
        public URLDbContext(DbContextOptions<URLDbContext> opts)
           : base(opts) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<URLModel> Urls { get; set; }
        public DbSet<About> About { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<URLModel>()
                .HasIndex(x => x.Url)
                .IsUnique();
        }
    }
}
