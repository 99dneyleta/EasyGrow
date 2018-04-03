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
    [Route("class")]
    public class ClassController : Controller
    {
        private readonly IModelService<Class, ClassDto, ClassPostDto> _modelService;
        public ClassController(IModelService<Class, ClassDto, ClassPostDto> modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetClasses()
        {
            try
            {
                var result = await _modelService.GetAllAsync();

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "Class Get: " + _modelService.GetType() + "all items: successfully"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.InernalServerError, LogCategory.Error,
                "Class Get: " + _modelService.GetType() + "all items failed: " + ex.Message));
                return StatusCode(LoggingEvents.InernalServerError, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetClass")]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetClassAsync(int id)
        {

            try
            {
                var result = await _modelService.GetAsync(id);

                if (result == null)
                {
                    LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NotFound, LogCategory.Warning,
                        "Class Get item " + id + ": Not Found"));

                    return NotFound("Entity not found");
                }

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "Class Get item " + id + ": successfully"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NoContent, LogCategory.Info,
                "Class Get item " + id + "failed:" + ex.Message));
                return StatusCode(LoggingEvents.InernalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateClassAsync(ClassPostDto model)
        {
            if (!ModelState.IsValid)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.BadRequest, LogCategory.Error,
                "Class Creating item: " + _modelService.GetType() + "- failed. Wrong input model."));
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _modelService.AddAsync(model);

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "Class Creating item: " + _modelService.GetType() + "- successfully"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.InernalServerError, LogCategory.Error,
                "Class Creating item: " + _modelService.GetType() + "- failed. " + ex.Message));
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
                "Class Deleting item: " + id + " Deleted"));

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NoContent, LogCategory.Warning,
                    "Class Deleting item: " + id + " Not Found" + ex.Message));
                return NotFound(new JsonResult(new { error = "Updated entity not found" }).Value);
            }
        }

        [HttpPatch]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateAsync(int id, ClassPostDto modelDto)
        {
            try
            {
                var res = await _modelService.UpdateAsync(id, modelDto);

                if (res == null)
                {
                    LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NotFound, LogCategory.Warning,
                        "Class Update item " + id + ": Not Found"));

                    return NotFound("Entity not found");
                }

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "Class Updating item: " + id + " Updated"));

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