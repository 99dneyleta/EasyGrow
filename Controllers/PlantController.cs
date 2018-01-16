using System;
using System.Collections.Generic;
using System.Linq;
using EasyGrow.DTO;
using EasyGrow.Helpers;
using EasyGrow.Interfaces;
using EasyGrow.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mapper = AutoMapper.Mapper;

namespace EasyGrow.Controllers
{
    [Produces("application/json")]
    [Route("plant")]
    public class PlantController : Controller
    {
        private readonly IPlantService _plantService;

        public PlantController(IPlantService plantService, IUserService userService)
        {
            _plantService = plantService;
        }

        [HttpGet]
        [Authorize(Roles = "admin,user")]
        public IActionResult GetAllPlants()
        {
            LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info, "Getting items: Done"));
            var allPlants = _plantService.GetAll().ToList();

            var allPlantsDto = allPlants.Select(element => Mapper.Map<PlantDto>(element)).ToList();
            return Ok(allPlantsDto);
        }

        [HttpGet("{id}", Name = "GetPlant")]
        [Authorize(Roles = "admin,user")]
        public IActionResult GetById(long id)
        {
            var plant = _plantService.Get(id);

            if (plant == null)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NotFound, LogCategory.Warning,
                    "Getting item: NotFound " + id));
                return NotFound(new JsonResult(new { error = "Entity not found" }).Value);
            }

            LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "Getting item: " + id + " Done"));
            return new ObjectResult(plant);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Create([FromBody] PlantDto plantDto)
        {
            if (!ModelState.IsValid)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.BadRequest, LogCategory.Warning,
                    "Creating item: " + " Bad Request"));
                return BadRequest(ModelState);
            }

            try
            {

                var newPlant = Mapper.Map<Plant>(_plantService.Create(plantDto));

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.CreateItem, LogCategory.Info,
                    "Creating item: " + newPlant.PlantId + " Done"));

                return Ok(newPlant);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.BadRequest, LogCategory.Warning,
                    "Creating item: Bad Request "));

                return BadRequest(new JsonResult(new { error = ex.InnerException.Message }).Value);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Update(long id, [FromBody] PlantDto plant)
        {

            if (!ModelState.IsValid)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.BadRequest, LogCategory.Warning,
                    "Updating item: " + id + " Bad Request"));
                return BadRequest(ModelState);
            }

            try
            {
                var updatedPlant = Mapper.Map<Plant>(_plantService.Update(id, plant));

                if (updatedPlant == null)
                {
                    LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NotFound, LogCategory.Warning,
                        "Updating item: " + id + " Not Found"));
                    return NotFound(new JsonResult(new { error = "Updated entity not found" }).Value);
                }

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                    "Updating item: " + id + " Updated"));

                return Ok(plant);
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResult(new { error = ex.InnerException.Message }).Value);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(long id)
        {
            string accessToken = ((Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.FrameRequestHeaders)Request.Headers)
                .HeaderAuthorization;
            var plant = Mapper.Map<Plant>(_plantService.Delete(id, accessToken));

            if (plant == null)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NoContent, LogCategory.Warning,
                    "Deleting item: " + id + " Not Found"));
                return NotFound(new JsonResult(new { error = "Updated entity not found" }).Value);
            }

            LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NoContent, LogCategory.Info,
                "Deleting item: " + id + " Deleted"));
            return new NoContentResult();
        }
    }
}