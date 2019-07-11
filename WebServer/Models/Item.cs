
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebServer.Models
{
    public class Item : Base
    {
        public Item()
        {
            Images = new List<Image>();
            Reviews = new List<Review>();
        }

        [Required, MinLength(6), MaxLength(100)]
        public string Name { get; set; }

        [Required, MinLength(5), MaxLength(100)]
        public string Title { get; set; }

        [Required, MinLength(5), MaxLength(3000)]
        public string Description { get; set; }

        [Required, DataType(DataType.Currency)]
        public double Price { get; set; }

        public virtual List<Review> Reviews { get; set; }

        [JsonIgnore]
        public virtual List<Image> Images { get; set; }
    }
}
