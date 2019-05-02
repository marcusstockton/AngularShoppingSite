using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebServer.Interfaces;
using WebServer.Models;
using WebServer.Models.DTOs;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsersController(IUserService userService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto userParam)
        {
            var user = await _userManager.FindByNameAsync(userParam.Username);
            var _passwordHasher = new PasswordHasher<ApplicationUser>();

            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, userParam.Password) != PasswordVerificationResult.Success)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            var user_token = _userService.Authenticate(user);

            return Ok(user);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllUsersWithoutFirstName()
        {
            var users = _userService.GetAllUsersWithoutFirstName();
            return Ok(users);
        }
    }
}