using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebServer.Data;
using WebServer.Helpers;
using WebServer.Interfaces;
using WebServer.Models.DTOs.Users;

namespace WebServer.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContext;

        public UserService(IOptions<AppSettings> appSettings, ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContext)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _userManager = userManager;
            _httpContext = httpContext;
        }
        public ApplicationUser Authenticate(ApplicationUser user)
        {
            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            
            return user;
        }

        public IEnumerable<ApplicationUser> GetAllUsersWithoutFirstName()
        {
            return _userManager.Users.Where(c => string.IsNullOrEmpty(c.FirstName));
        }

        public async Task<IdentityResult> RegisterUser(RegisterUser user)
        {
            var applicationUser = new ApplicationUser{
                UserName = user.Username,
                FirstName = user.FirstName,
                DoB = user.DoB,
                LastName = user.LastName
            };
            
            return await _userManager.CreateAsync(applicationUser, user.Password);
        }

        public async Task<ApplicationUser> ValidateUser(LoginDto userParam)
        {
            var user = await _userManager.FindByNameAsync(userParam.Username);
            var _passwordHasher = new PasswordHasher<ApplicationUser>();

            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, userParam.Password) != PasswordVerificationResult.Success)
            {
                return null;
            }
            return user;
        }

        public Guid GetLoggedInUserId()
        {
            var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(!string.IsNullOrEmpty(userId))
            {
                return Guid.Parse(userId);
            }
            return Guid.Empty;
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user != null)
            {
                return user;
            }
            return null;
        }
    }
}
