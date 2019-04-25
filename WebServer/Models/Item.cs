
using System.Collections.Generic;

namespace WebServer.Models
{
    public class Item : Base
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public virtual List<Review> Reviews { get; set; }
    }
}
