﻿using AutoMapper;
using EFCoreFromExistingDB;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;
using System.Linq;
using EFCoreFromExistingDB.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService _service;

        public UserController(IMapper mapper, IDataAccess dataAccess)
        {
            _service = new Service(dataAccess, mapper);
        }

        [HttpGet]
        public IActionResult Get()
        {
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
            var user = _service.GetUsers().FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            _service.DeleteUser(id);
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