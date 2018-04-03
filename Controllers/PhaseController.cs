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
    [Route("phase")]
    public class PhaseController : Controller
    {
        private readonly IModelService<Phase, PhaseDto, PhasePostDto> _modelService;
        public PhaseController(IModelService<Phase, PhaseDto, PhasePostDto> modelService)
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
                "Phase Get: " + _modelService.GetType() + "all items: successfully"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.InernalServerError, LogCategory.Error,
                "Phase Get: " + _modelService.GetType() + "all items failed: " + ex.Message));
                return StatusCode(LoggingEvents.InernalServerError, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetPhase")]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetAsync(int id)
        {

            try
            {
                var result = await _modelService.GetAsync(id);

                if (result == null)
                {
                    LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NotFound, LogCategory.Warning,
                        "Phase Get item " + id + ": Not Found"));

                    return NotFound("Entity not found");
                }

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "Phase Get item " + id + ": successfully"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NoContent, LogCategory.Info,
                "Phase Get item " + id + "failed:" + ex.Message));
                return StatusCode(LoggingEvents.InernalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateAsync(PhasePostDto model)
        {
            if (!ModelState.IsValid)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.BadRequest, LogCategory.Error,
                "Phase Creating item: " + _modelService.GetType() + "- failed. Wrong input model."));
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _modelService.AddAsync(model);

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "Phase Creating item: " + _modelService.GetType() + "- successfully"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.InernalServerError, LogCategory.Error,
                "Phase Creating item: " + _modelService.GetType() + "- failed. " + ex.Message));
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
                "Phase Deleting item: " + id + " Deleted"));

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NoContent, LogCategory.Warning,
                    "Phase Deleting item: " + id + " Not Found" + ex.Message));
                return NotFound(new JsonResult(new { error = "Updated entity not found" }).Value);
            }
        }

        [HttpPatch]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateAsync(int id, PhasePostDto modelDto)
        {
            try
            {
                var res = await _modelService.UpdateAsync(id, modelDto);

                if (res == null)
                {
                    LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NotFound, LogCategory.Warning,
                        "Phase Update item " + id + ": Not Found"));

                    return NotFound("Entity not found");
                }

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "Phase Updating item: " + id + " Updated"));

                return Ok(res);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.InernalServerError, LogCategory.Error,
                    "Phase Updating item: " + id + " Error where update;" + ex.Message));
                return StatusCode(LoggingEvents.InernalServerError, ex.Message);
            }
        }
    }
}