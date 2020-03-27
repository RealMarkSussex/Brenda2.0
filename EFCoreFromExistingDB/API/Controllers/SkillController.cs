using System.Linq;
using AutoMapper;
using EFCoreFromExistingDB;
using EFCoreFromExistingDB.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;

namespace API.Controllers
{
    [EnableCors("AllowOrigin")]
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : Controller
    {
        private readonly IService _service;

        public SkillController(IMapper mapper, IDataAccess dataAccess)
        {
            _service = new Service(dataAccess, mapper);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var skills = _service.GetSkills().ToList();
            if (!skills.Any())
            {
                return NotFound();
            }
            return new OkObjectResult(skills);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var skill = _service.GetSkills().FirstOrDefault(s => s.SkillId == id);
            if (skill == null)
            {
                return NotFound();
            }

            _service.DeleteSkill(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] ServiceSkill skill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _service.Add(skill);
            return Ok();
        }
    }
}