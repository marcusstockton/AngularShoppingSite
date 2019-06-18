using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebServer.Models.DTOs.Items
{
    public class ItemDetails
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public virtual IList<byte[]> Images { get; set; }
        public ApplicationUser CreatedBy { get; internal set; }
        public Guid Id { get; internal set; }
        public ApplicationUser UpdatedBy { get; internal set; }
        public DateTime? UpdatedDate { get; internal set; }
        public Guid CreatedById { get; internal set; }
        public Guid? UpdatedById { get; internal set; }
    }
}
