using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models.DTOs.Items
{
    public class ItemDetails
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public virtual List<Uri> Images { get; set; }
        public ApplicationUser CreatedBy { get; internal set; }
        public Guid Id { get; internal set; }
        public ApplicationUser UpdatedBy { get; internal set; }
        public DateTime? UpdatedDate { get; internal set; }
    }
}
