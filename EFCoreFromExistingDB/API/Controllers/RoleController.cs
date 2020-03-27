using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFCoreFromExistingDB;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.Interfaces;

namespace API.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IService _service;
        public RoleController(IMapper mapper)
        {
            _service = new Service(new DataAccess(), mapper);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new OkObjectResult(_service.GetRoles().FirstOrDefault(r => r.RoleId == id));
        }
    }
}