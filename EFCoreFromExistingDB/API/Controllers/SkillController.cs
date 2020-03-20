using AutoMapper;
using EFCoreFromExistingDB;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : Controller
    {
        private readonly IService _service;

        public SkillController(IMapper mapper)
        {
            _service = new Service(new DataAccess(), mapper);
        }
        [HttpGet]
        public IActionResult Get()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return new OkObjectResult(_service.GetServiceSkills());
        }
    }
}