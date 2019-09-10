using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Models;
using WebServer.Models.Items;

namespace WebServer.Data
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public DataSeeder(ApplicationDbContext context, IServiceProvider service, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async void SeedData()
        {
            if (!_context.Users.Any())
            {

                var validUser = new ApplicationUser()
                {
                    Id = Guid.NewGuid(),
                    Email = "test@test.com",
                    UserName = "testUser",
                    FirstName = "Marcus",
                    LastName = "Stockton",
                    DoB = new DateTime(1985, 4, 12)
                };
                var validUserResult = await _userManager.CreateAsync(validUser, "Pa$$w0rd");

                var noNameUser = new ApplicationUser()
                {
                    Id = Guid.NewGuid(),
                    Email = "someShit@test.com",
                    UserName = "noNamedUser",
                    DoB = new DateTime(1993, 1, 16)
                };
                var noNameUserResult = await _userManager.CreateAsync(noNameUser, "Pa$$w0rd");

                _context.SaveChanges();
            }
            if (!_context.DeliveryOptions.Any())
            {
                _context.DeliveryOptions.Add(new DeliveryOption
                {
                    Active = true,
                    Description = "1st Class Royal Mail",
                    CreatedBy = _context.Users.FirstOrDefault(),
                    CreatedById = _context.Users.FirstOrDefault().Id,
                    CreatedDate = DateTime.Now,
                    Id = new Guid(),
                });
                await _context.SaveChangesAsync();
            }

            if (!_context.ItemCategories.Any())
            {
                _context.ItemCategories.Add(new ItemCategory
                {
                    Description = "Mountain Bike",
                    CreatedBy = _context.Users.FirstOrDefault(),
                    CreatedById = _context.Users.FirstOrDefault().Id,
                    CreatedDate = DateTime.Now,
                    Id = new Guid(),
                    ParentCategory = new ItemCategory
                    {
                        Description = "Bicycles",
                        CreatedBy = _context.Users.FirstOrDefault(),
                        CreatedById = _context.Users.FirstOrDefault().Id,
                        CreatedDate = DateTime.Now,
                        Id = new Guid(),
                    }
                });
                await _context.SaveChangesAsync();
            }
            if (!_context.ItemConditions.Any())
            {
                _context.ItemConditions.Add(new ItemCondition
                {
                    Description = "New",
                    Active = true,
                    CreatedBy = _context.Users.FirstOrDefault(),
                    CreatedById = _context.Users.FirstOrDefault().Id,
                    CreatedDate = DateTime.Now,
                    Id = new Guid(),
                });
                await _context.SaveChangesAsync();
            }

            if (!_context.Items.Any())
            {
                _context.Items.Add(new Item
                {
                    Id = new Guid(),
                    Name = "Super Best thing ever!",
                    CreatedDate = DateTime.Now,
                    Description = "Some Description",
                    Title = "Some Title",
                    Price = 21.32,
                    Active = true,
                    ItemCondition = _context.ItemConditions.First(),
                    DeliveryOption = _context.DeliveryOptions.First(),
                    ItemCategory = _context.ItemCategories.First(),
                    CreatedBy = _context.Users.FirstOrDefault(),
                    CreatedById = _context.Users.FirstOrDefault().Id,
                    Reviews = new List<Review>
                    {
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now, Rating=3, Title="My First Review", Description = "My First Review Description", CreatedBy=_context.Users.LastOrDefault()},
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now.AddDays(-3), Rating=4, Title="Meh", Description = "It's Ok...", CreatedBy=_context.Users.LastOrDefault()}
                    }
                });
                _context.Items.Add(new Item
                {
                    Id = new Guid(),
                    Name = "OMG!!! YOLO",
                    CreatedDate = DateTime.Now,
                    Description = "Some Other Description",
                    Title = "Some Other Title",
                    Price = 123245,
                    Active = true,
                    ItemCondition = _context.ItemConditions.First(),
                    DeliveryOption = _context.DeliveryOptions.First(),
                    ItemCategory = _context.ItemCategories.First(),
                    CreatedBy = _context.Users.FirstOrDefault(),
                    CreatedById = _context.Users.FirstOrDefault().Id,
                    Reviews = new List<Review>
                    {
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now, Rating=1, Title="My Second Review", Description = "My Second Review Description", CreatedBy=_context.Users.LastOrDefault()}
                    }
                });
                _context.Items.Add(new Item
                {
                    Id = new Guid(),
                    Name = "The newest thing ever!!!",
                    CreatedDate = DateTime.Now,
                    Description = "Blah blah blah",
                    Title = "Some old guff",
                    Price = 0.12,
                    Active = true,
                    ItemCondition = _context.ItemConditions.First(),
                    DeliveryOption = _context.DeliveryOptions.First(),
                    ItemCategory = _context.ItemCategories.First(),
                    CreatedBy = _context.Users.FirstOrDefault(),
                    CreatedById = _context.Users.FirstOrDefault().Id,
                    Reviews = new List<Review>
                    {
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now, Rating=5, Title="My Third Review", Description = "My Third Review Description", CreatedBy=_context.Users.LastOrDefault()}
                    }
                });
                _context.Items.Add(new Item
                {
                    Id = new Guid(),
                    Name = "Worlds Best Mountain Bike",
                    CreatedDate = DateTime.Now,
                    Description = "The mountain bike of the future, today!",
                    Title = "Worlds Best Mountain Bike",
                    Price = 1220.12,
                    Active = true,
                    ItemCondition = _context.ItemConditions.First(),
                    DeliveryOption = _context.DeliveryOptions.First(),
                    ItemCategory = _context.ItemCategories.First(),
                    CreatedBy = _context.Users.FirstOrDefault(),
                    CreatedById = _context.Users.FirstOrDefault().Id,
                    Reviews = new List<Review>
                    {
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now, Rating=4, Title="My Fourth Review", Description = "My Fourth Review Description", CreatedBy=_context.Users.LastOrDefault()}
                    }
                });
                _context.Items.Add(new Item
                {
                    Id = new Guid(),
                    Name = "Acorn",
                    CreatedDate = DateTime.Now,
                    Description = "Acord from an oak tree. 100% Unique, no other like it in the world!",
                    Title = "An Acorn",
                    Price = 1220.12,
                    Active = true,
                    ItemCondition = _context.ItemConditions.First(),
                    DeliveryOption = _context.DeliveryOptions.First(),
                    ItemCategory = _context.ItemCategories.First(),
                    CreatedBy = _context.Users.FirstOrDefault(),
                    CreatedById = _context.Users.FirstOrDefault().Id,
                    Reviews = new List<Review>
                    {
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now, Rating=5, Title="My Fifth Review", Description = "My Fifth Review Description", CreatedBy=_context.Users.LastOrDefault()}
                    }
                });
                _context.Items.Add(new Item
                {
                    Id = new Guid(),
                    Name = "Used Frizbee",
                    CreatedDate = DateTime.Now,
                    Description = "A frizbee thats been used before, usual wear and tear for a used frizbee.",
                    Title = "Used Frizbee",
                    Price = 4.25,
                    Active = true,
                    ItemCondition = _context.ItemConditions.First(),
                    DeliveryOption = _context.DeliveryOptions.First(),
                    ItemCategory = _context.ItemCategories.First(),
                    CreatedBy = _context.Users.FirstOrDefault(),
                    CreatedById = _context.Users.FirstOrDefault().Id,
                    Reviews = new List<Review>
                    {
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now, Rating=2, Title="My Sixth Review", Description = "My Sixth Review Description", CreatedBy=_context.Users.LastOrDefault()}
                    }
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
