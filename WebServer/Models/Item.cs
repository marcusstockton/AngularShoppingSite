
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebServer.Models
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
        public double Price { get; set; }
        public virtual List<Review> Reviews { get; set; }

        [JsonIgnore]
        public virtual List<Image> Images { get; set; }
    }
}
