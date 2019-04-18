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
                    CreatedDate = DateTime.Now,
                    Description = "Some Description",
                    Title = "Some Title",
                    Price = 21.32,
                });
                _context.Items.Add(new Item
                {
                    Id = new Guid(),
                    CreatedDate = DateTime.Now,
                    Description = "Some Other Description",
                    Title = "Some Other Title",
                    Price = 123245,
                });
                _context.Items.Add(new Item
                {
                    Id = new Guid(),
                    CreatedDate = DateTime.Now,
                    Description = "Blah blah blah",
                    Title = "Some old guff",
                    Price = 0.12,
                });

                _context.SaveChanges();
            }
        }
    }
}
