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

        public async Task<IEnumerable<ItemDetails>> GetItems()
        {
            var items = await _context.Items
                .Include(x=>x.CreatedBy)
                .Include(x=>x.UpdatedBy)
                .OrderByDescending(x=>x.CreatedDate)
                .AsNoTracking()
                .ToListAsync();
            return Mapper.Map<IEnumerable<Item>, IEnumerable<ItemDetails>>(items);

        }

        public async Task<ItemDetails> GetItemById(Guid Id){
            var result = await _context.Items
                .Include(x=>x.Reviews)
                .Include(x=>x.Images)
                .Include(x=>x.CreatedBy)
                .Include(x=>x.UpdatedBy)
                .Where(i=>i.Id == Id)
                .SingleOrDefaultAsync();

            return _mapper.Map<ItemDetails>(result);
        }

        public async Task<Item> UpdateItemById(Guid id, ItemEdit itemdto, List<Image> images){
            if(itemdto.Id == id)
            {
                var mappedItem = _mapper.Map<Item>(itemdto);

                var item = await _context.Items
                    .Include(x=>x.CreatedBy)
                    .Include(x=>x.Images)
                    .Include(x => x.Reviews)
                    .Include(x=>x.UpdatedBy)
                    .SingleOrDefaultAsync(x=>x.Id == id);

                item.UpdatedById = _userService.GetLoggedInUserId();
                item.UpdatedDate = DateTime.Now;
                item.Images.AddRange(images);
                _context.Entry(item).CurrentValues.SetValues(itemdto); // CreatedBy appears to be null... causing the constraint.

                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }

        public async Task<Item> CreateItem(ItemCreate itemdto, List<Image> images)
        {
            var item = _mapper.Map<Item>(itemdto);
            item.CreatedById = _userService.GetLoggedInUserId();
            item.CreatedDate = DateTime.Now;
            item.Images.AddRange(images);
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteItemById(Guid id)
        {
            var item = await _context.Items.FindAsync(id);
            if(item == null)
            {
                return false;
            }
            try 
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
