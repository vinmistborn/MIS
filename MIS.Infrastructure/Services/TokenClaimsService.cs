using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MIS.Domain.Entities.Identity;
using MIS.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Infrastructure.Services
{
   public class TokenClaimsService : ITokenClaimsService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        public TokenClaimsService(UserManager<User> userManager,
                                  IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task<string> GetTokenAsync(User appUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var user = await _userManager.FindByEmailAsync(appUser.Email);
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, appUser.UserName) };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = Encoding.UTF8.GetBytes(_config["JWT:Key"]);
            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new JwtSecurityToken(
                _config["JWT:Issuer"],
                _config["JWT:Audience"],
                claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds);            
            var token = tokenHandler.WriteToken(tokenDescriptor);
            return token;
        }
    }
}
