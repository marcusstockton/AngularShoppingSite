using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Models;

namespace WebServer.Interfaces
{
    public interface IItemsService
    {
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItemById(Guid Id);
        Task<bool> UpdateItemById(Guid id, Item item);
    }
}
