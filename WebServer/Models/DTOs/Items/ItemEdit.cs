using System;
using System.Collections.Generic;
using WebServer.Models.DTOs.Reviews;
using WebServer.Models.DTOs.Users;


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
    }
}
