using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyGrow.Data;
using EasyGrow.Helpers;
using EasyGrow.Interfaces;
using EasyGrow.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyGrow.Controllers
{
    [Produces("application/json")]
    [Route("checkplant")]
    public class CheckPlantController : Controller
    {
        private readonly IPlantService _plantService;
        private readonly PlantContext _context;


        public CheckPlantController(IPlantService plantService, PlantContext context)
        { 
            _plantService = plantService;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CheckPlant(long id)
        {
            string accessToken = ((Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.FrameRequestHeaders)Request.Headers)
                .HeaderAuthorization;

            if (accessToken == null)
            {
                return BadRequest("Cannot get access Token");
            }
            var user = JwtHelper.GetUserJwt(accessToken, _context
                );

            if (user == null)
            {
                return BadRequest("Undefined user");
            }

            var userplant = _context.UserPlants.Select(x => x.PlantId == id && x.ApplicationUser.Email == user.Email);

            if (!userplant.Contains(true))
            {
                return BadRequest("User haven't this plant");
            }

            var plant = Mapper.Map<Plant>(_plantService.Get(id));

            if (plant == null)
            {
                return BadRequest("Db haven't this plant");
            }

            var geolocation = _context.Geolocations.FirstOrDefault(p => p.GeolocationId == user.GeolocationId);

            if (geolocation == null)
            {
                return BadRequest("User haven't this geolocation");
            }

            try
            {
                if (!await Weather.IsRain(plant.FrequencyOfWateringDays, geolocation))
                    return Ok("Need water");
                else
                    return Ok("Don't need water");
            }
            catch (Exception weatherEx)
            {
                return BadRequest(weatherEx.InnerException.Message);
            }
        }
    }
}