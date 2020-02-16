using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using WebServer.Models;
using WebServer.Models.Items;

namespace WebServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCondition> ItemConditions {get;set;}
        public DbSet<ItemCategory> ItemCategories {get;set;}
        public DbSet<DeliveryOption> DeliveryOptions {get;set;}
        public DbSet<Image> Images { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<ApplicationUser>().Property(p => p.Id).ValueGeneratedOnAdd();
            //builder.Entity<Item>().Property(p=>p.Id).ValueGeneratedOnAdd();
            //builder.Entity<ItemCondition>().Property(p=>p.Id).ValueGeneratedOnAdd();
            //builder.Entity<ItemCategory>().Property(p=>p.Id).ValueGeneratedOnAdd();
            //builder.Entity<DeliveryOption>().Property(p=>p.Id).ValueGeneratedOnAdd();

            builder.Entity<Image>().HasOne(x=>x.Item).WithMany(x=>x.Images).HasForeignKey(x=>x.ItemId);
            
            builder.Entity<Review>().HasOne(x=>x.Item).WithMany().HasForeignKey(x=>x.ItemId);

            builder.Entity<Item>().Property(x=>x.Name).HasMaxLength(100).IsRequired();
            builder.Entity<Item>().Property(x=>x.Title).HasMaxLength(300).IsRequired();
            builder.Entity<Item>().Property(x=>x.Description).HasMaxLength(3000).IsRequired();
            builder.Entity<Item>().Property(x=>x.Price).IsRequired();

            builder.Entity<Review>().Property(x=>x.Title).HasMaxLength(300);
        }
    }
}
