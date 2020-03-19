using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EFCoreFromExistingDB.Interfaces;
using EFCoreFromExistingDB.Models;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;

namespace ServiceLayer
{
    public class Service : IService
    {
        private readonly IDataAccess _database;
        public Service(IDataAccess database)
        {
            _database = database;
        }
        public IEnumerable<ServiceSkill> GetServiceSkills()
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Skill, ServiceSkill>(); });
            var mapper = new Mapper(config);
            var skills = _database.GetSkills();
            var serviceSkill = new ServiceSkill();

            return skills.Select(skill => mapper.Map(skill, serviceSkill)).ToList();
        }
    }
}
