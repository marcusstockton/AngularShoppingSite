using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Models;
using WebServer.Models.DTOs.Items;

namespace WebServer.Interfaces
{
    public interface IItemsService
    {
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItemById(Guid Id);
        Task<bool> UpdateItemById(Guid id, ItemEdit item);
        Task<int> CreateItem(ItemCreate item);
         Task<bool> DeleteItemById(Guid id);
    }
}
