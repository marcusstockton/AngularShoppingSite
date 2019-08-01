using System;
using WebServer.Models.DTOs.Users;

namespace WebServer.Models.DTOs.Reviews
{
    public class ReviewEdit
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public UserDetails CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
