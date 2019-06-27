using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models.DTOs.Items
{
    public class ItemCreate : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public List<Image> Images { get; set; }
    }
}
