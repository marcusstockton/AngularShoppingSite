using System;


namespace WebServer.Models.DTOs.Items
{
    public class ItemEdit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid ItemCategoryId { get; set; }
        public Guid ItemConditionId { get; set; }
        public Guid DeliveryOptionId { get; set; }
    }
}
