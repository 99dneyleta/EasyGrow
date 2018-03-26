using System;
using EasyGrow.DTO;
using EasyGrow.Helpers;
using EasyGrow.Interfaces;
using EasyGrow.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyGrow.Controllers
{
    [Produces("application/json")]
    [Route("groundwater_level")]
    public class GroundwaterLevelController : Controller
    {
        private readonly IModelService<GroundwaterLevel, GroundWaterDto> _modelService;
        public GroundwaterLevelController(IModelService<GroundwaterLevel, GroundWaterDto> testmodelService)
        {
            _modelService = testmodelService;
        }

        [HttpGet]
        [Authorize(Roles = "admin,user")]
        public IActionResult GetAllGroundwaterLevels()
        {
            try
            {
                return (Ok(_modelService.GetAll()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetGroundwaterLevel")]
        [Authorize(Roles = "admin,user")]
        public IActionResult GetById(int id)
        {

            try
            {
                return (Ok(_modelService.Get(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult CreateGroundwaterLevel(GroundWaterDto model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(_modelService.Add(model));
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);

            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                _modelService.Delete(id);
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NoContent, LogCategory.Info,
                "Deleting item: " + id + " Deleted"));
                return new NoContentResult();
            }
            catch
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NoContent, LogCategory.Warning,
                    "Deleting item: " + id + " Not Found"));
                return NotFound(new JsonResult(new { error = "Updated entity not found" }).Value);
            }
        }

        [HttpPatch]
        [Authorize(Roles = "admin")]
        public IActionResult Update(int id, GroundWaterDto modelDto)
        {
            try
            {
                _modelService.Update(id, modelDto);
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "Updating item: " + id + " Updated"));
                return Ok(modelDto);
            }
            catch
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.InernalServerError, LogCategory.Error,
                    "Updating item: " + id + " Error where update"));
                return StatusCode(500);
            }
        }
    }
}