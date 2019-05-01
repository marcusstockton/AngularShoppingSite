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
using WebServer.Models;

namespace WebServer.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly ApplicationDbContext _context;

        public UserService(IOptions<AppSettings> appSettings, ApplicationDbContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }
        public User Authenticate(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == username && x.Password == password);

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
                    new Claim(ClaimTypes.Name, user.Username),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            // return users without passwords
            return _context.Users.Where(x => x.Password == null ).AsEnumerable();
        }
    }
}
