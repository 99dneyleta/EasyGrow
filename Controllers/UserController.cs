
using EasyGrow.Helpers;
using EasyGrow.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using AutoMapper;
using EasyGrow.DTO;
using Microsoft.AspNetCore.Identity;
using EasyGrow.Models;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace EasyGrow.Controllers
{
    [Produces("application/json")]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public UserController(IUserService userService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async System.Threading.Tasks.Task<IActionResult> GetAllUsersAsync()
        {
            var allUsers = _userService.GetAll().ToList();
            try
            {
                var users = await _userManager.Users
            .AsNoTracking()
            .ProjectTo<ApplicationUserDto>(new { roles = _roleManager.Roles })
            .ToListAsync();
                var allPlantsDto = Mapper.Map<ApplicationUserDto>(allUsers.First());
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info, "Getting user items: Done"));
                
                return Ok(allPlantsDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("getalluserplant")]
        [Authorize(Roles = "admin,user")]
        public IActionResult GetAllUserPlants()
        {
            string accessToken = ((Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.FrameRequestHeaders)Request.Headers)
               .HeaderAuthorization;
            var allUserPlants = _userService.GetAllUserPlants(accessToken);

            LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info, "Getting all user plant: Done"));
            return Ok(allUserPlants);
        }

        [HttpPost]
        [Authorize(Roles = "admin,user")]
        public IActionResult AddPlantToUser(long plantId)
        {
            string accessToken = ((Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.FrameRequestHeaders)Request.Headers)
               .HeaderAuthorization;
            try
            {
                var plant = _userService.AddPlantToUser(accessToken, plantId);
                return Ok(plant);
            }
            catch
            {
                return BadRequest();
            }


        }
    }
}
