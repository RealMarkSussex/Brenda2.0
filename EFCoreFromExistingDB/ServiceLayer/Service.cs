using System.Collections;
using AutoMapper;
using EFCoreFromExistingDB.Interfaces;
using EFCoreFromExistingDB.Models;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;
using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<ServiceSkill> GetServiceSkills() => 
            _mapper.Map<IEnumerable<Skill>, IEnumerable<ServiceSkill>>(_database.GetSkills());

        public IEnumerable<ServiceUser> GetUsers()
        {
            var serviceUsers = _mapper.Map<IEnumerable<User>, IEnumerable<ServiceUser>>(_database.GetUsers()).ToList();
            var newServiceUsers = new List<ServiceUser>();
            var userSkills = _database.GetUserSkills().ToList();
            foreach (var user in serviceUsers)
            {
                user.UserSkill = userSkills.Where(us => us.UserId == user.UserId).ToList();
                newServiceUsers.Add(user);
            }
            return newServiceUsers;
        }
    }
}
