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

        public SkillController()
        {
            _service = new Service(new DataAccess());
        }
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_service.GetServiceSkills());
        }
    }
}