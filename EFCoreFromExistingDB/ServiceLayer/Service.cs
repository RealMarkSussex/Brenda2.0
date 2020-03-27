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
            _database.DeleteSkill(id);

            foreach (var skillLevel in _database.GetSkillLevels().Where(sl => sl.SkillId == id))
            {
                _database.DeleteSkillLevel(skillLevel.SkillLevelId);
            }
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
            var users = _mapper.Map<IEnumerable<User>, IEnumerable<ServiceUser>>(_database.GetUsers()).ToList();
            var serviceUsers = new List<ServiceUser>();

            foreach (var user in users)
            {
                user.UserSkill = GetUserSkills(user.UserId).ToList();
                serviceUsers.Add(user);
            }
            return serviceUsers;
        }

        public void Add(ServiceUser user)
        {
            _database.Add(_mapper.Map<ServiceUser, User>(user));
        }

        public void DeleteUser(int id)
        {
            foreach (var userSkill in _database.GetUserSkills().Where(us => us.UserId == id))
            {
                _database.DeleteUserSkill(userSkill.UserSkillId);
            }

            _database.DeleteUser(id);
        }

        public void Update(ServiceUser user)
        {
            _database.Update(_mapper.Map<ServiceUser, User>(user));
        }

        public IEnumerable<ServiceRole> GetRoles()
        {
            return _mapper.Map<IEnumerable<Role>, IEnumerable<ServiceRole>>(_database.GetRoles());
        }

        public IEnumerable<ServiceLevel> GetLevels()
        {
            return _mapper.Map<IEnumerable<Level>, IEnumerable<ServiceLevel>>(_database.GetLevels());
        }

        public IEnumerable<ServiceSkillLevel> GetSkillLevels()
        {
            return _mapper.Map<IEnumerable<SkillLevel>, IEnumerable<ServiceSkillLevel>>(_database.GetSkillLevels());
        }

        private IEnumerable<UserSkill> GetUserSkills(int userId)
        {
            return _database.GetUserSkills().Where(us => us.UserId == userId);
        }
    }
}
