using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyGrow.DTO;
using EasyGrow.Helpers;
using EasyGrow.Interfaces;
using EasyGrow.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyGrow.Controllers
{
    [Produces("application/json")]
    [Route("test")]
    public class TestController : Controller
    {
        private readonly IModelService<TestModel,TestModelDto> _modelInterface;

        public TestController(IModelService<TestModel,TestModelDto> testmodelService)
        {
            _modelInterface = testmodelService;
        }

        [HttpGet]
        [Authorize(Roles = "admin,user")]
        public IActionResult GetAllPlants()
        {
            try
            {
                return(Ok(_modelInterface.GetAll()));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin,user")]
        public IActionResult CreateTest(TestModelDto model)
        {
            var k = _modelInterface.Add(model);
            return Ok(k);
        }

        [HttpGet("{id}", Name = "Test")]
        [Authorize(Roles = "admin,user")]
        public IActionResult GetById(int id)
        {

            try
            {
                return (Ok(_modelInterface.Get(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    
}
