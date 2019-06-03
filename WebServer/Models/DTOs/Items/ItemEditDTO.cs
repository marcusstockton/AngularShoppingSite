using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models.DTOs.Items
{
    public class ItemEditDTO
    {
        public ItemEdit item { get; set; }
        public List<IFormFile> fileArray { get; set; }
    }
}
