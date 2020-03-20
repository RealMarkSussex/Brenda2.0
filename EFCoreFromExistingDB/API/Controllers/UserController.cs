using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFCoreFromExistingDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService _service;

        public UserController(IMapper mapper)
        {
            _service = new Service(new DataAccess(), mapper);
        }

        [HttpGet]
        public IActionResult Get()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return new OkObjectResult(_service.GetUsers());
        }
    }
}