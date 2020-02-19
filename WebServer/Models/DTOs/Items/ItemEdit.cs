using System;
using System.Collections.Generic;
using WebServer.Models.DTOs.Reviews;
using WebServer.Models.DTOs.Users;
using WebServer.Models.Items;


namespace WebServer.Models.DTOs.Items
{
    public class ItemEdit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public UserDetails CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserDetails UpdatedBy { get; set; }
        public virtual List<ReviewDetails> Reviews { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ItemCondition ItemCondition { get; set; }
        public virtual DeliveryOption DeliveryOption { get; set; }
        public virtual List<Image> Images { get; set; }
    }
}
