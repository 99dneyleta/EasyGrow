
using EasyGrow.Helpers;
using EasyGrow.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using AutoMapper;
using EasyGrow.DTO;

namespace EasyGrow.Controllers
{
    [Produces("application/json")]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult GetAllUsers()
        {
            LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info, "Getting user items: Done"));

            var allUsers = _userService.GetAll().ToList();

            var allPlantsDto = allUsers.Select(Mapper.Map<ApplicationUserDto>).ToList();
            return Ok(allPlantsDto);

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
