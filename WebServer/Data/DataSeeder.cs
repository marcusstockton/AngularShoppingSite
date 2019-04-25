using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Models;

namespace WebServer.Data
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;
        public DataSeeder(ApplicationDbContext context, IServiceProvider service)
        {
            _context = context;
        }

        public void SeedData()
        {

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
                    Reviews = new List<Review>
                    {
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now, Rating=3, Title="My First Review", Description = "My First Review Description"}
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
                    Reviews = new List<Review>
                    {
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now, Rating=1, Title="My Second Review", Description = "My Second Review Description"}
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
                    Reviews = new List<Review>
                    {
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now, Rating=5, Title="My Third Review", Description = "My Third Review Description"}
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
                    Reviews = new List<Review>
                    {
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now, Rating=4, Title="My Fourth Review", Description = "My Fourth Review Description"}
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
                    Reviews = new List<Review>
                    {
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now, Rating=5, Title="My Fifth Review", Description = "My Fifth Review Description"}
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
                    Reviews = new List<Review>
                    {
                        new Review{Id = new Guid(), CreatedDate = DateTime.Now, Rating=2, Title="My Sixth Review", Description = "My Sixth Review Description"}
                    }
                });
                _context.SaveChanges();
            }
        }
    }
}
