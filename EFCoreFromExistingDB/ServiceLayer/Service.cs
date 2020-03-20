using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EFCoreFromExistingDB;
using EFCoreFromExistingDB.Interfaces;
using EFCoreFromExistingDB.Models;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;

namespace ServiceLayer
{
    public class Service : IService
    {
        private readonly IDataAccess _database;
        private readonly IMapper _mapper;
        public Service(IDataAccess database, IMapper mapper)
        {
            _mapper = mapper;
            _database = database;
        }
        public IEnumerable<ServiceSkill> GetServiceSkills()
        {
            var skills = _database.GetSkills();
            return _mapper.Map<IEnumerable<Skill>, IEnumerable<ServiceSkill>>(skills);
        }
    }
}
