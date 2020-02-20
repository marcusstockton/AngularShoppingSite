using System;
using System.Collections.Generic;
using WebServer.Models.DTOs.Images;
using WebServer.Models.DTOs.Reviews;

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
        public virtual IList<ImageDetails> Images { get; set; }
        public string CreatedBy { get; internal set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; internal set; }
        public DateTime? UpdatedDate { get; internal set; }
        public KeyValuePair<Guid, string> ItemCategoryDto { get; set; }
        public KeyValuePair<Guid, string> ItemConditionDto { get; set; }
        public KeyValuePair<Guid, string> DeliveryOptionDto { get; set; }
    }
}
