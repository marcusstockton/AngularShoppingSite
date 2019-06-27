using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebServer.Interfaces;
using WebServer.Models.DTOs.Users;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
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

        /// <summary>
        /// End point for authenticating individual user account.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /authenticate
        ///     {
        ///        "username": "testUser",
        ///        "password": "Pa$$w0rd"
        ///     }
        ///
        /// </remarks>
        /// <param name="userParam"></param>
        /// <returns>User object with auth token.</returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto userParam)
        {
            var validUser = await _userService.ValidateUser(userParam);
            if (validUser == null)
            {
                return BadRequest();
            }
            var user_token = _userService.Authenticate(validUser);

            return Ok(user_token);
        }


        /// <summary>
        /// Register a new user
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /register
        ///     {
        ///        "username": "testUser",
        ///        "password": "password",
        ///        "firstName": "John",
        ///        "lastname": "Doe",
        ///        "dob": "1 mar 1998"
        ///     }
        /// </remarks>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUser user)
        {
            var result = await _userService.RegisterUser(user);
            if(result.Succeeded){
                return Ok();
            }
            return(BadRequest(result.Errors));
            
        }

        /// <summary>
        /// Gets all users who don't have a first name set
        /// </summary>
        /// <returns>A IEnumerable of ApplicationUsers without a first name.</returns>
        [HttpGet]
        public IActionResult GetAllUsersWithoutFirstName()
        {
            var users = _userService.GetAllUsersWithoutFirstName();
            return Ok(users);
        }
    }
}