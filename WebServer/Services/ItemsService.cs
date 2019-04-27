using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Data;
using WebServer.Interfaces;
using WebServer.Models;

namespace WebServer.Services
{
    public class ItemsService : IItemsService
    {
        private readonly ApplicationDbContext _context;

        public ItemsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemById(Guid Id){
            return await _context.Items.Include(x=>x.Reviews).Where(i=>i.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateItemById(Guid id, Item item){
            if(item.Id == id)
            {
                // Update the item
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
