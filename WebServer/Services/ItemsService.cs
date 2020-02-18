using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Data;
using WebServer.Interfaces;
using WebServer.Models;
using WebServer.Models.DTOs.Items;
using WebServer.Models.Items;


namespace WebServer.Services
{
    public class ItemsService : IItemsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ItemsService(ApplicationDbContext context, IUserService userService, IMapper mapper, ILoggerFactory logger)
        {
            _context = context;
            _userService = userService;
            _mapper = mapper;
            _logger = logger.CreateLogger( "ItemsService" );
        }

        public async Task<IEnumerable<ItemDetails>> GetItems()
        {
            _logger.LogInformation("Calling Get Items");
            var items = await _context.Items
                .Include(x=>x.CreatedBy)
                .Include(x=>x.UpdatedBy)
                .OrderByDescending(x=>x.CreatedDate)
                .AsNoTracking()
                .ToListAsync();
            if(items == null)
            {
                _logger.LogWarning( "No items found" );
            }
            return _mapper.Map<IEnumerable<Item>, IEnumerable<ItemDetails>>(items);

        }

        public async Task<ItemDetails> GetItemById(Guid Id){
            _logger.LogInformation( $"Calling Get Item with Id {Id}" );
            var result = await _context.Items
                .Include(x=>x.Reviews)
                .Include(x=>x.Images)
                .Include(x=>x.CreatedBy)
                .Include(x=>x.UpdatedBy)
                .Include(x=>x.ItemCategory)
                .Where(i=>i.Id == Id)
                .SingleOrDefaultAsync();
            if(result == null)
            {
                _logger.LogWarning( $"No item found with id {Id}" );
            }
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
                    .Include(x=>x.ItemCategory)
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
