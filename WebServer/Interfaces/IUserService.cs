using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Models;
using WebServer.Models.DTOs.Users;
using Microsoft.AspNetCore.Identity;

namespace WebServer.Interfaces
{
    public interface IUserService
    {
        ApplicationUser Authenticate(ApplicationUser user);
        IEnumerable<ApplicationUser> GetAllUsersWithoutFirstName();
        Task<IdentityResult> RegisterUser(RegisterUser user);
        Task<ApplicationUser> ValidateUser(LoginDto userParam);
    }
}
