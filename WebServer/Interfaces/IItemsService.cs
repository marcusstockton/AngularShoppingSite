using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebServer.Models;
using WebServer.Models.DTOs.Items;

namespace WebServer.Interfaces
{
    public interface IItemsService
    {
        Task<IEnumerable<ItemDetails>> GetItems();
        Task<ItemDetails> GetItemById(Guid Id);
        Task<Item> UpdateItemById(Guid id, ItemEdit item, List<Image> images);
        Task<Item> CreateItem(ItemCreate item);
        Task<bool> DeleteItemById(Guid id);
    }
}
