using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebServer.Models.DTOs.Users;

namespace WebServer.Interfaces
{
    public interface IUserService
    {
        ApplicationUser Authenticate(ApplicationUser user);
        IEnumerable<ApplicationUser> GetAllUsersWithoutFirstName();
        Task<IdentityResult> RegisterUser(RegisterUser user);
        Task<ApplicationUser> ValidateUser(LoginDto userParam);
        Guid GetLoggedInUserId();
    }
}
