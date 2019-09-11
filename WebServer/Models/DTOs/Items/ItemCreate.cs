using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Models.Items;

namespace WebServer.Models.DTOs.Items
{
    public class ItemCreate
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ItemCondition ItemCondition { get; set; }
        public virtual DeliveryOption DeliveryOption { get; set; }
    }
}
