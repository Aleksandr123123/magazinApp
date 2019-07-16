using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PresentationLayer.Models;
using PresentationLayer.Servieces.Interfaces;

namespace InternetMagazin.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountManager _accountManager;
        private readonly ApplicationSetting _applicationSetting;

        public AccountController(IAccountManager accountManager, IOptions<ApplicationSetting> appSetting)
        {
            _accountManager = accountManager;
            _applicationSetting = appSetting.Value;
        }



        
     
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _accountManager.GetUserByNameAsync(model.UserName);

            if (user != null && await _accountManager.CheckPasswordAsync(user, model.Password))
            {
                var role = await _accountManager.GetUserRolesAsync(user);
                IdentityOptions options = new IdentityOptions();

                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                            new Claim("UserID",user.Id.ToString()),
                            new Claim(options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_applicationSetting.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
            
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescription);
                var token = tokenHandler.WriteToken(securityToken);
                
                return Ok(new {token});
            }
        
            else


                return BadRequest(new { message = "Username or password is incorrect." });

        }


        [HttpGet]
        [Route("users")]
        public IActionResult GetUsers()
        {
            return  Ok(_accountManager.GetUsersAndRolesAsync());
        }


        [HttpGet]
        [Authorize]
        [Route("UserProfile")]
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _accountManager.GetUserByIdAsync(userId);
          
            Customer customer =  _accountManager.GetCustomerByUser(user).Result;
            if (customer != null)
            {
                return new
                {
                    user.FullName,
                    user.UserName,
                    customer.Id

                };
            }
            return new
            {
                user.FullName,
                user.UserName
            };

        }
    }
}
