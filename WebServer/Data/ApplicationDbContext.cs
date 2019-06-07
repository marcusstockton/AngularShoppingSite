using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using WebServer.Models;

namespace WebServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Item>().Property(p=>p.Id).ValueGeneratedOnAdd();
            builder.Entity<Image>().Property(p=>p.Id).ValueGeneratedOnAdd();

            builder.Entity<Image>().HasOne(x=>x.Item).WithMany(x=>x.Images).HasForeignKey(x=>x.ItemId);
        }
    }
}
