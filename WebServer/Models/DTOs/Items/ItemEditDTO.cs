using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WebServer.Models.DTOs.Items
{
    public class ItemEditDTO
    {
        public ItemEdit item { get; set; }
        public List<IFormFile> fileArray { get; set; }
    }
}
