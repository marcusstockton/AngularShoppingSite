using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models.DTOs.Items
{
    public class ItemEdit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public virtual List<Review> Reviews { get; set; }
        //public virtual List<IFormFile> Images { get; set; }
    }
}
