using BLL.Domain;
using BLL.Services.Abstract;
using CIL.DTOs;
using CIL.Models;
using DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class UserAuthService : IUserAuthService
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;
        private readonly DatabaseContext databaseContext;

        public UserAuthService(UserManager<User> userManager, IConfiguration configuration, DatabaseContext databaseContext)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.databaseContext = databaseContext;
        }

        public async Task<AuthenticationResult> RegisterAsync(UserRegisterModel registerModel)
        {
            var existingUser = await userManager.FindByNameAsync(registerModel.Username);

            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User with such username already exists" }
                };
            }
            var newUser = new User
            {
                Name = registerModel.Name,
                Surname = registerModel.Surname,
                BirthDate = registerModel.BirthDate,
                UserName = registerModel.Username,
                Email = registerModel.Email,
                PasswordHash = registerModel.PasswordHash,
                UserLevel = registerModel.UserLevel,
                UserRole = registerModel.UserRole
            };

            var createdUser = await userManager.CreateAsync(newUser, registerModel.PasswordHash);


            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createdUser.Errors.Select(x => x.Description)
                };
            }

            return GenerateAuthenticationResultForUser(newUser);
        }

        public async Task<AuthenticationResult> LoginAsync(UserLoginModel loginModel)
        {
            var user = await userManager.FindByNameAsync(loginModel.Username);

            if (user == null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User does not exist" }
                };
            }
            var userHasValidPassword = await userManager.CheckPasswordAsync(user, loginModel.Password);

            if (!userHasValidPassword)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User credentials are wrong" }
                };
            }


            return GenerateAuthenticationResultForUser(user);
        }

        private AuthenticationResult GenerateAuthenticationResultForUser(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["JWT:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.UserRole),
                    new Claim("id", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = configuration["JWT:ValidIssuer"],
                Audience = configuration["JWT:ValidAudience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                AccessToken = tokenHandler.WriteToken(token),
                Username = user.UserName,
                UserRole = user.UserRole
            };
        }
    }
}
