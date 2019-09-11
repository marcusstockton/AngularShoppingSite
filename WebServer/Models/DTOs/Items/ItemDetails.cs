using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WebServer.Helpers;
using WebServer.Models.DTOs.Reviews;
using WebServer.Models.DTOs.Users;
using WebServer.Models.Items;

namespace WebServer.Models.DTOs.Items
{
    public class ItemDetails
    {
        public Guid Id { get; internal set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public virtual List<ReviewDetails> Reviews { get; set; }
        public virtual IList<Image> Images { get; set; }
        public UserDetails CreatedBy { get; internal set; }
        public DateTime CreatedDate { get; set; }
        public UserDetails UpdatedBy { get; internal set; }
        public DateTime? UpdatedDate { get; internal set; }
        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ItemCondition ItemCondition { get; set; }
        public virtual DeliveryOption DeliveryOption { get; set; }
    }
}
