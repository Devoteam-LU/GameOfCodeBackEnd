using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Privilege.Business.Models;
using Privilege.Database.DatabaseModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Privilege.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ApplicationUserController : ControllerBase
    {
        public ApplicationUserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<ApiParameters> appSettings)
        {
            UserManager = userManager;
            SingInManager = signInManager;
            RoleManager = roleManager;
            ApiParameters = appSettings.Value;
        }

        private RoleManager<IdentityRole> RoleManager { get; }
        private ApiParameters ApiParameters { get; }
        private SignInManager<ApplicationUser> SingInManager { get; }
        private UserManager<ApplicationUser> UserManager { get; }

        [HttpGet]
        [Route("UserProfile")]
        public async Task<UserDto> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await UserManager.FindByIdAsync(userId);
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Apy = user.Apy,
                CreditScore = user.CreditScore,
            };
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<string> Login(LoginDto model)
        {
            var user = await UserManager.FindByNameAsync(model.Username);
            if (user != null && await UserManager.CheckPasswordAsync(user, model.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ApiParameters.JWTSecret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return token;
            }
            else
                throw new InvalidCredentialException();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<Object> PostApplicationUser(ApplicationUserDto model)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
            };

            try
            {
                var result = await UserManager.CreateAsync(applicationUser, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
