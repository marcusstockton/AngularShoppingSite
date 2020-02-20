using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebServer.Models;
using WebServer.Models.DTOs.Items;
using WebServer.Models.Items;

namespace WebServer.Interfaces
{
    public interface IItemsService
    {
        Task<IEnumerable<ItemDetails>> GetItems();
        Task<ItemDetails> GetItemById(Guid Id);
        Task<Item> UpdateItemById(Guid id, ItemEdit item);
        Task<Item> CreateItem(ItemCreate item, List<Image> images);
        Task<bool> DeleteItemById(Guid id);
    }
}
