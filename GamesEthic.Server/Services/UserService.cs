using GamesEthic.Server.Models.Config;
using GamesEthic.Server.Models.DTOs.User;
using GamesEthic.Server.Models.Entities;
using GamesEthic.Server.Services.Interfaces;
using GamesEthic.Server.Services.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GamesEthic.Server.Services
{
    public sealed class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly JwtSettings _jwt;

        public UserService(UserManager<User> userManager, IOptions<JwtSettings> jwtOptions)
        {
            _userManager = userManager;
            _jwt = jwtOptions.Value;
        }

        public async Task<UserTO> GetUser(string? email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new Exception("User not found");
            var roles = await _userManager.GetRolesAsync(user);
            return user.ToUserTO(roles);
        }

        public async Task<AuthUserTO> Login(LoginUserTO loginUserTO)
        {
            var user = await _userManager.FindByNameAsync(loginUserTO.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginUserTO.Password))
                throw new Exception("Invalid credentials");

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
            new Claim(ClaimTypes.Name, user.UserName ?? "")
        };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience:_jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new AuthUserTO
            {
                Token = tokenString,
                Email = user.Email!,
                UserName = user.UserName!,
                Roles = roles
            };
        }
    }
}
