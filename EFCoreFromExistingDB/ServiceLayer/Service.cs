using AutoMapper;
using EFCoreFromExistingDB.Interfaces;
using EFCoreFromExistingDB.Models;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;
using System.Collections.Generic;

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
        public IEnumerable<ServiceSkill> GetServiceSkills() => _mapper.Map<IEnumerable<Skill>, IEnumerable<ServiceSkill>>(_database.GetSkills());
        
    }
}
