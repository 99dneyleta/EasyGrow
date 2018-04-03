using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyGrow.DTO;
using EasyGrow.DTO.PostDto;
using EasyGrow.Helpers;
using EasyGrow.Interfaces;
using EasyGrow.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyGrow.Controllers
{
    [Produces("application/json")]
    [Route("geolocation")]
    public class GeolocationController : Controller
    {
        private readonly IModelService<Geolocation, GeolocationDto, GeolocationPostDto> _modelService;
        public GeolocationController(IModelService<Geolocation, GeolocationDto, GeolocationPostDto> modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _modelService.GetAllAsync();

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "Geolocation Get: " + _modelService.GetType() + "all items: successfully"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.InernalServerError, LogCategory.Error,
                "Geolocation Get: " + _modelService.GetType() + "all items failed: " + ex.Message));
                return StatusCode(LoggingEvents.InernalServerError, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetGeolocation")]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetAsync(int id)
        {

            try
            {
                var result = await _modelService.GetAsync(id);

                if (result == null)
                {
                    LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NotFound, LogCategory.Warning,
                        "Geolocation Get item " + id + ": Not Found"));

                    return NotFound("Entity not found");
                }

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "Geolocation Get item " + id + ": successfully"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NoContent, LogCategory.Info,
                "Geolocation Get item " + id + "failed:" + ex.Message));
                return StatusCode(LoggingEvents.InernalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateAsync(GeolocationPostDto model)
        {
            if (!ModelState.IsValid)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.BadRequest, LogCategory.Error,
                "Geolocation Creating item: " + _modelService.GetType() + "- failed. Wrong input model."));
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _modelService.AddAsync(model);

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "Geolocation Creating item: " + _modelService.GetType() + "- successfully"));

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
                "Geolocation Deleting item: " + id + " Deleted"));

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NoContent, LogCategory.Warning,
                    "Geolocation Deleting item: " + id + " Not Found" + ex.Message));
                return NotFound(new JsonResult(new { error = "Updated entity not found" }).Value);
            }
        }

        [HttpPatch]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateAsync(int id, GeolocationPostDto modelDto)
        {
            try
            {
                var res = await _modelService.UpdateAsync(id, modelDto);

                if (res == null)
                {
                    LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NotFound, LogCategory.Warning,
                        "Geolocation Update item " + id + ": Not Found"));

                    return NotFound("Entity not found");
                }

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "Geolocation Updating item: " + id + " Updated"));

                return Ok(res);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.InernalServerError, LogCategory.Error,
                    "Geolocation Updating item: " + id + " Error where update;" + ex.Message));
                return StatusCode(LoggingEvents.InernalServerError, ex.Message);
            }
        }
    }
}