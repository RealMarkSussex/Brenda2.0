using System;
using System.Collections.Generic;
using System.Text;
using EFCoreFromExistingDB.Interfaces;
using EFCoreFromExistingDB.Models;
using EFCoreFromExistingDB.Repositories;

namespace EFCoreFromExistingDB
{
    public class DataAccess : IDataAccess
    {
        private readonly UserRepo _userRepo;
        private readonly SkillRepo _skillRepo;
        private readonly RoleRepo _roleRepo;
        private readonly SkillLevelRepo _skillLevelRepo;
        private readonly UserSkillRepo _userSkillRepo;
        private readonly LevelRepo _levelRepo;
        public DataAccess()
        {
            _userRepo = new UserRepo();
            _skillRepo = new SkillRepo();
            _roleRepo = new RoleRepo();
            _skillLevelRepo = new SkillLevelRepo();
            _userSkillRepo = new UserSkillRepo();
            _levelRepo = new LevelRepo();
        }

        public IEnumerable<Level> GetLevels() => _levelRepo.Get();

        public void Add(Level level) => _levelRepo.Add(level);

        public void DeleteLevel(int id) => _levelRepo.Delete(id);

        public void Update(Level level) => _levelRepo.Update(level);


        public IEnumerable<Role> GetRoles() => _roleRepo.Get();

        public void Add(Role role) => _roleRepo.Add(role);

        public void DeleteRole(int id) => _roleRepo.Delete(id);

        public void Update(Role role) => _roleRepo.Update(role);


        public IEnumerable<Skill> GetSkills() => _skillRepo.Get();

        public void Add(Skill skill) => _skillRepo.Add(skill);

        public void DeleteSkill(int id) => _skillRepo.Delete(id);

        public void Update(Skill skill) => _skillRepo.Update(skill);


        public IEnumerable<SkillLevel> GetSkillLevels() => _skillLevelRepo.Get();

        public void Add(SkillLevel skillLevel) => _skillLevelRepo.Add(skillLevel);

        public void DeleteSkillLevel(int id) => new SkillLevelRepo().Delete(id);

        public void Update(SkillLevel skillLevel) => _skillLevelRepo.Update(skillLevel);


        public IEnumerable<User> GetUsers() => _userRepo.Get();

        public void Add(User user) => _userRepo.Add(user);

        public void DeleteUser(int id) => _userRepo.Delete(id);

        public void Update(User user) => _userRepo.Update(user);


        public IEnumerable<UserSkill> GetUserSkills() => _userSkillRepo.Get();

        public void Add(UserSkill userSkill) => _userSkillRepo.Add(userSkill);

        public void DeleteUserSkill(int id) => _userSkillRepo.Delete(id);

        public void Update(UserSkill userSkill) => _userSkillRepo.Update(userSkill);
    }
}
