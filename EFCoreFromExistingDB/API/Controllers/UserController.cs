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
using ServiceLayer.Models;

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
            var users = _service.GetUsers();
            if (!users.Any())
            {
                return NotFound();
            }
            return new OkObjectResult(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            var user = _service.GetUsers().FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            return new OkObjectResult(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ServiceUser user)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _service.Add(user);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            var user = _service.GetUsers().FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            _service.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] ServiceUser user)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            var potentialUser = _service.GetUsers().FirstOrDefault(u => u.UserId == user.UserId);
            if (potentialUser == null)
            {
                return NotFound();
            }

            _service.Update(user);
            return Ok();
        }
    }
}