using System.Linq;
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
            var skills = _service.GetServiceSkills().ToList();
            if (!skills.Any())
            {
                return NotFound();
            }
            return new OkObjectResult(skills);
        }
    }
}