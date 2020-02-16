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
                _context.DeliveryOptions.AddRange(new DeliveryOption {
                    Active = true,
                    Description = "1st Class Royal Mail",
                    CreatedBy = _context.Users.FirstOrDefault(),
                    CreatedById = _context.Users.FirstOrDefault().Id,
                    CreatedDate = DateTime.Now,
                    Id = new Guid(),
                }, new DeliveryOption {
                    Active = true,
                    Description = "2nd Class Royal Mail",
                    CreatedBy = _context.Users.FirstOrDefault(),
                    CreatedById = _context.Users.FirstOrDefault().Id,
                    CreatedDate = DateTime.Now,
                    Id = new Guid(),
                });
                
                await _context.SaveChangesAsync();
            }

            if (!_context.ItemCategories.Any())
            {
                _context.ItemCategories.AddRange(new ItemCategory {
                    Description = "Mountain Bike",
                    CreatedBy = _context.Users.FirstOrDefault(),
                    CreatedById = _context.Users.FirstOrDefault().Id,
                    CreatedDate = DateTime.Now,
                    Id = new Guid(),
                    Active = true,
                    ParentCategory = new ItemCategory
                    {
                        Description = "Bicycles",
                        CreatedBy = _context.Users.FirstOrDefault(),
                        CreatedById = _context.Users.FirstOrDefault().Id,
                        CreatedDate = DateTime.Now,
                        Active = true,
                        Id = new Guid(),
                    }
                }, new ItemCategory {
                    Description = "Computers",
                    CreatedBy = _context.Users.FirstOrDefault(),
                    CreatedById = _context.Users.FirstOrDefault().Id,
                    CreatedDate = DateTime.Now,
                    Id = new Guid(),
                    Active = true,
                    ParentCategory = new ItemCategory
                    {
                        Description = "Electronics",
                        CreatedBy = _context.Users.FirstOrDefault(),
                        CreatedById = _context.Users.FirstOrDefault().Id,
                        CreatedDate = DateTime.Now,
                        Active = true,
                        Id = new Guid(),
                    }
                });


                
                await _context.SaveChangesAsync();
            }
            if (!_context.ItemConditions.Any())
            {
                _context.ItemConditions.AddRange(new ItemCondition {
                    Description = "New",
                    Active = true,
                    CreatedBy = _context.Users.FirstOrDefault(),
                    CreatedById = _context.Users.FirstOrDefault().Id,
                    CreatedDate = DateTime.Now,
                    Id = new Guid(),
                }, new ItemCondition {
                    Description = "Used",
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
                    Id = new Guid("cb863fa3-f9d0-4a23-9378-049388b25f29"),
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
                    Images = new List<Image>
                    {
                        new Image{
                            Active = true,
                            CreatedBy = _context.Users.First(),
                            CreatedDate = DateTime.Now,
                            Path = "Uploads/img/95bc4dfc182045769ea3faa6d4752b25.jpg",
                            FileName = "95bc4dfc182045769ea3faa6d4752b25.jpg",
                            Type = ".jpg",
                            ItemId = new Guid("cb863fa3-f9d0-4a23-9378-049388b25f29")
                        },
                        new Image{
                            Active = true,
                            CreatedBy = _context.Users.First(),
                            CreatedDate = DateTime.Now,
                            Path = "Uploads/img/a1f26b6f667092bf3b6aa299b6e9bb65.jpg",
                            FileName = "a1f26b6f667092bf3b6aa299b6e9bb65.jpg",
                            Type = ".jpg",
                            ItemId = new Guid("cb863fa3-f9d0-4a23-9378-049388b25f29")
                        }
                    },
                    Reviews = new List<Review>
                    {
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now, Rating=3, Title="My First Review", Description = "My First Review Description", CreatedBy=_context.Users.OrderBy(x=>x.FirstName).FirstOrDefault(), ItemId = new Guid("cb863fa3-f9d0-4a23-9378-049388b25f29")},
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now.AddDays(-3), Rating=4, Title="Meh", Description = "It's Ok...", CreatedBy=_context.Users.FirstOrDefault(), ItemId = new Guid("cb863fa3-f9d0-4a23-9378-049388b25f29")}
                    }
                });
                _context.Items.Add(new Item
                {
                    Id = new Guid("6f917a1f-84cb-4b5d-a067-c29cba99a081"),
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
                    Images = new List<Image> {
                        new Image {
                        Active = true,
                        CreatedBy = _context.Users.First(),
                        CreatedDate = DateTime.Now,
                        Path = "Uploads/img/debea43fe42fb1a84ba5fd444c4ccd1a.jpg",
                        FileName = "debea43fe42fb1a84ba5fd444c4ccd1a.jpg",
                        Type = ".jpg",
                        ItemId = new Guid("6f917a1f-84cb-4b5d-a067-c29cba99a081")
                        }
                    },
                    Reviews = new List<Review>
                    {
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now, Rating=1, Title="My Second Review", Description = "My Second Review Description", CreatedBy=_context.Users.FirstOrDefault(), ItemId = new Guid("6f917a1f-84cb-4b5d-a067-c29cba99a081")}
                    }
                });
                _context.Items.Add(new Item
                {
                    Id = new Guid("d90a78ae-b90d-49ff-b2ae-9f468f4475db"),
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
                    Images = new List<Image>
                    {
                        new Image
                        {
                            Active = true,
                            CreatedBy = _context.Users.First(),
                            CreatedDate = DateTime.Now,
                            Path = "Uploads/img/Class-1b.jpg",
                            FileName = "Class-1b.jpg",
                            Type = ".jpg",
                            ItemId = new Guid("d90a78ae-b90d-49ff-b2ae-9f468f4475db")
                        }
                    },
                    Reviews = new List<Review>
                    {
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now, Rating=5, Title="My Third Review", Description = "My Third Review Description", CreatedBy=_context.Users.FirstOrDefault(), ItemId = new Guid("d90a78ae-b90d-49ff-b2ae-9f468f4475db")}
                    }
                });
                _context.Items.Add(new Item
                {
                    Id = new Guid("e9c50177-c7b8-48e0-b33e-0be91990f508"),
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
                    Images = new List<Image>
                    {
                        new Image
                        {
                            Active = true,
                            CreatedBy = _context.Users.First(),
                            CreatedDate = DateTime.Now,
                            Path = "Uploads/img/61046430_10158400863506521_6337056367861301248_n.jpg",
                            FileName = "61046430_10158400863506521_6337056367861301248_n.jpg",
                            Type = ".jpg",
                            ItemId = new Guid("e9c50177-c7b8-48e0-b33e-0be91990f508")
                        },
                        new Image
                        {
                            Active = true,
                            CreatedBy = _context.Users.First(),
                            CreatedDate = DateTime.Now,
                            Path = "Uploads/img/Dark Angels.jpg",
                            FileName = "Dark Angels.jpg",
                            Type = ".jpg",
                            ItemId = new Guid("e9c50177-c7b8-48e0-b33e-0be91990f508")
                        }
                    },
                    Reviews = new List<Review>
                    {
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now, Rating=4, Title="My Fourth Review", Description = "My Fourth Review Description", CreatedBy=_context.Users.FirstOrDefault(), ItemId = new Guid("e9c50177-c7b8-48e0-b33e-0be91990f508")}
                    }
                });
                _context.Items.Add(new Item
                {
                    Id = new Guid("7aa133d7-a98c-4021-8a55-617bbeb20b6d"),
                    Name = "Acorn",
                    CreatedDate = DateTime.Now,
                    Description = "Acorn from an oak tree. 100% Unique, no other like it in the world!",
                    Title = "An Acorn",
                    Price = 1220.12,
                    Active = true,
                    ItemCondition = _context.ItemConditions.First(),
                    DeliveryOption = _context.DeliveryOptions.First(),
                    ItemCategory = _context.ItemCategories.First(),
                    CreatedBy = _context.Users.FirstOrDefault(),
                    CreatedById = _context.Users.FirstOrDefault().Id,
                    Images = new List<Image>
                    {
                        new Image
                        {
                            Active = true,
                            CreatedBy = _context.Users.First(),
                            CreatedDate = DateTime.Now,
                            Path = "Uploads/img/FUXNT6EGPBDH5KR.LARGE.jpg",
                            FileName = "FUXNT6EGPBDH5KR.LARGE.jpg",
                            Type = ".jpg",
                            ItemId = new Guid("7aa133d7-a98c-4021-8a55-617bbeb20b6d")
                        },
                        new Image
                        {
                            Active = true,
                            CreatedBy = _context.Users.First(),
                            CreatedDate = DateTime.Now,
                            Path = "Uploads/img/91EAGFh6YPL._SY606_.jpg",
                            FileName = "91EAGFh6YPL._SY606_.jpg",
                            Type = ".jpg",
                            ItemId = new Guid("7aa133d7-a98c-4021-8a55-617bbeb20b6d")
                        }
                    },
                    Reviews = new List<Review>
                    {
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now, Rating=5, Title="My Fifth Review", Description = "My Fifth Review Description", CreatedBy=_context.Users.FirstOrDefault(), ItemId = new Guid("7aa133d7-a98c-4021-8a55-617bbeb20b6d")}
                    }
                });
                _context.Items.Add(new Item
                {
                    Id = new Guid("fccc84b0-ab04-4796-9a9a-e5f3533fd30b"),
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
                    Images = new List<Image>
                    {
                        new Image
                        {
                            Active = true,
                            CreatedBy = _context.Users.First(),
                            CreatedDate = DateTime.Now,
                            Path = "Uploads/img/FUXNT6EGPBDH5KR.LARGE.jpg",
                            FileName = "FUXNT6EGPBDH5KR.LARGE.jpg",
                            Type = ".jpg",
                            ItemId = new Guid("fccc84b0-ab04-4796-9a9a-e5f3533fd30b")
                        },
                        new Image
                        {
                            Active = true,
                            CreatedBy = _context.Users.First(),
                            CreatedDate = DateTime.Now,
                            Path = "Uploads/img/forest-wallpaper.jpg",
                            FileName = "forest-wallpaper.jpg",
                            Type = ".jpg",
                            ItemId = new Guid("fccc84b0-ab04-4796-9a9a-e5f3533fd30b")
                        }
                    },
                    Reviews = new List<Review>
                    {
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now, Rating=2, Title="My Sixth Review", Description = "My Sixth Review Description", CreatedBy=_context.Users.FirstOrDefault(), ItemId = new Guid("fccc84b0-ab04-4796-9a9a-e5f3533fd30b")}
                    }
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
