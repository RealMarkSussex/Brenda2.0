using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFCoreFromExistingDB.Interfaces;
using GemBox.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IService _service;
        public ExcelController(IMapper mapper, IDataAccess dataAccess)
        {
            _service = new Service(dataAccess, mapper);
        }
        [HttpGet]
        public IActionResult Get()
        {
            var excel = new SkillExcel(_service);
            return File(excel.Create(), SaveOptions.XlsxDefault.ContentType, "Skills.xlsx");
        }
    }
}