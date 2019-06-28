using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Models.DTOs.Users;

namespace WebServer.Models.DTOs.Reviews
{
    public class ReviewDetails
    {
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public UserDetails CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
