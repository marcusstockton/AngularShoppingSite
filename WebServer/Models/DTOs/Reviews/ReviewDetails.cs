using System;
using WebServer.Models.DTOs.Users;

namespace WebServer.Models.DTOs.Reviews
{
    public class ReviewDetails
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public UserDetails CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public UserDetails UpdatedBy { get; set; }
    }
}
