using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebServer.Models.Items
{
    public class Item : Base
    {
        public Item()
        {
            Images = new List<Image>();
            Reviews = new List<Review>();
        }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public bool Sold{get;set;}

        public virtual ItemCondition ItemCondition{get;set;}

        public virtual ItemCategory ItemCategory { get; set; }

        public virtual DeliveryOption DeliveryOption{get;set;}

        public virtual List<Review> Reviews { get; set; }

        public virtual List<Image> Images { get; set; }
    }
}
