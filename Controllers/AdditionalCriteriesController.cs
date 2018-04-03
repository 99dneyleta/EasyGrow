using System;
using System.Threading.Tasks;
using EasyGrow.DTO;
using EasyGrow.DTO.PostDto;
using EasyGrow.Helpers;
using EasyGrow.Interfaces;
using EasyGrow.Models;
using EasyGrow.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyGrow.Controllers
{
    [Produces("application/json")]
    [Route("additional_criteries")]
    public class AdditionalCriteriesController : Controller
    {
        private readonly IModelService<AdditionalCriteries, AdditionalCriteriesDto, AdditionalCriteriesPostDto> _modelService;
        private IAdditionalCriteriesService _additionalCriteriesService;
        public AdditionalCriteriesController(IModelService<AdditionalCriteries, AdditionalCriteriesDto, AdditionalCriteriesPostDto> modelService, 
            IAdditionalCriteriesService additionalCriteriesService)
        {
            _modelService = modelService;
            _additionalCriteriesService = additionalCriteriesService;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllAdditionalCriteriesAsync()
        {
            try
            {
                var result = await _additionalCriteriesService.GetAllCriteriesAsync();

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "AdditionalCriteries Get: " + _modelService.GetType() + "all items: successfully"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.InernalServerError, LogCategory.Error,
                "AdditionalCriteries Get: " + _modelService.GetType() + "all items failed: " + ex.Message));
                return StatusCode(LoggingEvents.InernalServerError, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetGetAdditionalCriteries")]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetAsync(int id)
        {

            try
            {
                var result = await _additionalCriteriesService.GetAdditionalCriteriesAsync(id);

                if (result == null)
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
                return StatusCode(LoggingEvents.InernalServerError, ex.Message);
            }
        }
        
        [HttpPost]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> CreateAdditionalCriteriesAsync(AdditionalCriteriesPostDto model)
        {
            if (!ModelState.IsValid)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.BadRequest, LogCategory.Error,
                "AdditionalCriteries Creating item: " + _modelService.GetType() + "- failed. Wrong input model."));
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _modelService.AddAsync(model);

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "AdditionalCriteries Creating item: " + _modelService.GetType() + "- successfully"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.InernalServerError, LogCategory.Error,
                "AdditionalCriteries Creating item: " + _modelService.GetType() + "- failed. " + ex.Message));
                return StatusCode(LoggingEvents.InernalServerError, ex.Message);
            }
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _modelService.DeleteAsync(id);

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NoContent, LogCategory.Info,
                " AdditionalCriteries Deleting item: " + id + " Deleted"));

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NoContent, LogCategory.Warning,
                    "AdditionalCriteries Deleting item: " + id + " Not Found" + ex.Message));
                return NotFound(new JsonResult(new { error = "Deleting entity not found" }).Value);
            }
        }

        [HttpDelete("delete_foreign_key/{id}")]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> DeleteForeignKeyAsync(int id)
        {
            try
            {
                await _additionalCriteriesService.DeleteForeignKeyAsync(id);

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NoContent, LogCategory.Info,
                " AdditionalCriteries Deleting foreign key in: " + id + " Deleted"));

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NoContent, LogCategory.Warning,
                    "AdditionalCriteries Deleting foreign key in: " + id + " Not Found" + ex.Message));
                return NotFound(new JsonResult(new { error = "Deleting entity not found" }).Value);
            }
        }

        [HttpPatch]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> UpdateAsync(int id, AdditionalCriteriesPostDto modelDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var res = await _additionalCriteriesService.UpdateAsync(id, modelDto);

                if (res == null)
                {
                    LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.NotFound, LogCategory.Warning,
                        "AdditionalCriteries Update item " + id + ": Not Found"));

                    return NotFound("Entity not found");
                }

                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.Ok, LogCategory.Info,
                "AdditionalCriteries Updating item: " + id + " Updated"));

                return Ok(res);
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(LogWriter.CreateLog(LoggingEvents.InernalServerError, LogCategory.Error,
                    "AdditionalCriteries Updating item: " + id + " Error where update;" + ex.Message));
                return StatusCode(LoggingEvents.InernalServerError, ex.Message);
            }
        }
        
    }
}
