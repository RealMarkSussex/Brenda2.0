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
        public IEnumerable<ServiceSkill> GetSkills()
        {
            var skills = _database.GetSkills().ToList();
            var newSkills = new List<Skill>();
            foreach (var skill in skills)
            {
                skill.SkillLevel = _database.GetSkillLevels().Where(sl => sl.SkillId == skill.SkillId).ToList();
                newSkills.Add(skill);
            }
            return _mapper.Map<IEnumerable<Skill>, IEnumerable<ServiceSkill>>(newSkills);

        }
        public void DeleteSkill(int id)
        {
            foreach (var skillLevel in _database.GetSkillLevels().Where(sl => sl.SkillId == id))
            {
                _database.DeleteSkillLevel(skillLevel.SkillLevelId);
            }
            _database.DeleteSkill(id);
        }

        public void Add(ServiceSkill skill)
        {
            _database.Add(_mapper.Map<ServiceSkill, Skill>(skill));
            var skillAdded = _database.GetSkills().Last();
            _database.Add(_mapper.Map<ServiceSkillLevel, SkillLevel>(new ServiceSkillLevel()
            {
                SkillId = skillAdded.SkillId,
                Description = skill.Level1Description,
                LevelId = 1
            }));
            _database.Add(_mapper.Map<ServiceSkillLevel, SkillLevel>(new ServiceSkillLevel()
            {
                SkillId = skillAdded.SkillId,
                Description = skill.Level2Description,
                LevelId = 2
            }));
            _database.Add(_mapper.Map<ServiceSkillLevel, SkillLevel>(new ServiceSkillLevel()
            {
                SkillId = skillAdded.SkillId,
                Description = skill.Level3Description,
                LevelId = 3
            }));
            _database.Add(_mapper.Map<ServiceSkillLevel, SkillLevel>(new ServiceSkillLevel()
            {
                SkillId = skillAdded.SkillId,
                Description = skill.Level4Description,
                LevelId = 4
            }));
        }

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

        public void DeleteUser(int id)
        {
            _database.DeleteUser(id);
        }

        public void Update(ServiceUser user)
        {
            _database.Update(_mapper.Map<ServiceUser, User>(user));
        }
    }
}
