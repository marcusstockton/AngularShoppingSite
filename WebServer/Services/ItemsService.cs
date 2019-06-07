using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Data;
using WebServer.Interfaces;
using WebServer.Models;
using WebServer.Models.DTOs.Items;

namespace WebServer.Services
{
    public class ItemsService : IItemsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ItemsService(ApplicationDbContext context, IUserService userService, IMapper mapper)
        {
            _context = context;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemById(Guid Id){
            return await _context.Items
                .Include(x=>x.Reviews)
                .Include(x=>x.Images)
                .Include(x=>x.CreatedBy)
                .Include(x=>x.UpdatedBy)
                .Where(i=>i.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateItemById(Guid id, ItemEdit itemdto, List<Image> images){
            if(itemdto.Id == id)
            {
                var item = _mapper.Map<Item>(itemdto);
                item.UpdatedById = _userService.GetLoggedInUserId();
                item.UpdatedDate = DateTime.Now;
                item.Images = images;
                _context.Items.Attach(item);

                _context.Entry(item).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    throw;
                }
            }
            return false;
        }

        public async Task<int> CreateItem(ItemCreate itemdto)
        {
            var item = _mapper.Map<Item>(itemdto);
            item.CreatedById = _userService.GetLoggedInUserId();
            item.CreatedDate = DateTime.Now;
            var result = await _context.AddAsync(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteItemById(Guid id)
        {
            var item = await _context.Items.FindAsync(id);
            try 
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
