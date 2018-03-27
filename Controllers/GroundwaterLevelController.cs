using System;
using System.Threading.Tasks;
using EasyGrow.DTO;
using EasyGrow.DTO.PostDto;
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
        private readonly IModelService<GroundwaterLevel, GroundWaterDto, GroundWaterPostDto> _modelService;
        public GroundwaterLevelController(IModelService<GroundwaterLevel, GroundWaterDto, GroundWaterPostDto> testmodelService)
        {
            _modelService = testmodelService;
        }

        [HttpGet]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetAllGroundwaterLevelsAsync()
        {
            try
            {
                var result = await _modelService.GetAllAsync();

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "Get: " + _modelService.GetType() + "all items: successfully"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.InernalServerError, LogCategory.Error,
                "Get: " + _modelService.GetType() + "all items failed: " + ex.Message));
                return StatusCode(LoggingEvents.InernalServerError, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetGroundwaterLevel")]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetByNameAsync(int id)
        {

            try
            {
                var result = await _modelService.GetAsync(id);

                if(result == null)
                {
                    LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NotFound, LogCategory.Warning,
                        "Get item " + id + ": Not Found"));

                    return NotFound("Entity not found");
                }

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "Get item " + id + ": successfully"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NoContent, LogCategory.Info,
                "Get item " + id + "failed:" + ex.Message));
                return StatusCode(LoggingEvents.InernalServerError,ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateGroundwaterLevelAsync(GroundWaterPostDto model)
        {
            if (!ModelState.IsValid)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.BadRequest, LogCategory.Error,
                "Creating item: " + _modelService.GetType() + "- failed. Wrong input model."));
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _modelService.AddAsync(model);

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "Creating item: " + _modelService.GetType() + "- successfully"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.InernalServerError, LogCategory.Error,
                "Creating item: " + _modelService.GetType() + "- failed. " + ex.Message));
                return StatusCode(LoggingEvents.InernalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _modelService.DeleteAsync(id);

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NoContent, LogCategory.Info,
                "Deleting item: " + id + " Deleted"));

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NoContent, LogCategory.Warning,
                    "Deleting item: " + id + " Not Found" + ex.Message));
                return NotFound(new JsonResult(new { error = "Updated entity not found" }).Value);
            }
        }

        [HttpPatch]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateAsync(int id, GroundWaterPostDto modelDto)
        {
            try
            {
                var res = await _modelService.UpdateAsync(id, modelDto);

                if (res == null)
                {
                    LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NotFound, LogCategory.Warning,
                        "Update item " + id + ": Not Found"));

                    return NotFound("Entity not found");
                }

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "Updating item: " + id + " Updated"));

                return Ok(res);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.InernalServerError, LogCategory.Error,
                    "Updating item: " + id + " Error where update;" + ex.Message));
                return StatusCode(LoggingEvents.InernalServerError, ex.Message);
            }
        }
    }
}