using EasyGrow.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EasyGrow.Models;
using EasyGrow.Helpers;
using Microsoft.EntityFrameworkCore;

namespace EasyGrow.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            RoleManager<IdentityRole> roleManager
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        [HttpPost("/login")]

        public async Task<object> Login([FromBody] LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded)
            {
                try
                {
                    var appUser = await _userManager.Users.SingleOrDefaultAsync(r => r.Email == model.Email);
                    try
                    {
                        var res = GenerateJwtToken(model.Email, appUser);
                        LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                        "User " + appUser.Email + " loged in"));
                        return res;
                    }
                    catch (Exception generateTokenEx)
                    {
                        return BadRequest(generateTokenEx.InnerException.Message);
                    }
                }
                catch (Exception ex)
                {
                    BadRequest(error: ex.InnerException.Message);
                }
            }
            LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.BadRequest, LogCategory.Warning,
                        "User trying sign in with wrong creds"));
            return BadRequest("Wrong creds");
        }

        [HttpPost("/register")]
        public async Task<object> Register([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                GeolocationId = model.GeolocationId
            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                var adminRole = await _roleManager.FindByNameAsync("user");
                if (adminRole == null)
                {
                    return StatusCode(500) + "Can't find role user ";
                }

                if (result.Succeeded)
                {
                    try
                    {
                        await _userManager.AddToRoleAsync(user, "user");
                    }
                    catch
                    {
                        return StatusCode(500) + "Can't add to role user " + user;
                    }

                    try
                    {
                        await _signInManager.SignInAsync(user, false);
                    }
                    catch (Exception signInEx)
                    {
                        return StatusCode(500) + signInEx.InnerException.Message;
                    }

                    try
                    {
                        var token = GenerateJwtToken(model.Email, user);
                        LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                        "User registred with email ") + model.Email);
                        return token;
                    }
                    catch (Exception genJwtEx)
                    {
                        return StatusCode(500) + (genJwtEx.InnerException.Message);
                    }

                }
            }
            catch (Exception createUserEx)
            {
                return StatusCode(500) + (createUserEx.InnerException.Message);
            }
            return BadRequest("Register_ERROR");
        }

        private object GenerateJwtToken(string email, ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, _userManager.GetRolesAsync(user).Result.First())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
