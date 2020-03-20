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
            var skillLevels = _database.GetSkillLevels().ToList();
            var newSkillLevels = new List<SkillLevel>();

            foreach (var skillLevel in skillLevels)
            {
                skillLevel.Skill = _database.GetSkills().FirstOrDefault(s => s.SkillId == skillLevel.SkillId);
                skillLevel.Level = _database.GetLevels().FirstOrDefault(l => l.LevelId == skillLevel.LevelId);
                newSkillLevels.Add(skillLevel);
            }

            foreach (var user in serviceUsers)
            {
                var specificUserSkills = userSkills.Where(us => us.UserId == user.UserId).ToList();
                foreach (var userSkill in specificUserSkills)
                {
                    user.UserSkills = newSkillLevels.Where(sl => sl.SkillLevelId == userSkill.SkillLevelId).ToList();
                }
                newServiceUsers.Add(user);
            }
            return newServiceUsers;
        }

        public void Add(ServiceUser user)
        {
            _database.Add(_mapper.Map<ServiceUser, User>(user));
        }

        public void Delete(ServiceUser user)
        {
            _database.Delete(_mapper.Map<ServiceUser, User>(user));
        }
    }
}
