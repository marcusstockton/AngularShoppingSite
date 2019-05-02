using Microsoft.AspNetCore.Identity;
using System;

public class ApplicationUser: IdentityUser<Guid>
{
    public string Token { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DoB { get; set; }
}