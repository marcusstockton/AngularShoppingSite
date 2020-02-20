using System;

namespace WebServer.Models.DTOs.Users
{
    public class UserDetails
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
