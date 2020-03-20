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
        public IEnumerable<Level> GetLevels() => LevelRepo.Get();

        public void Add(Level level) => LevelRepo.Add(level);

        public void Delete(Level level) => LevelRepo.Delete(level);

        public void Update(Level level) => LevelRepo.Update(level);


        public IEnumerable<Role> GetRoles() => RoleRepo.Get();

        public void Add(Role role) => RoleRepo.Add(role);

        public void Delete(Role role) => RoleRepo.Delete(role);

        public void Update(Role role) => RoleRepo.Update(role);


        public IEnumerable<Skill> GetSkills() => SkillRepo.Get();

        public void Add(Skill skill) => SkillRepo.Add(skill);

        public void Delete(Skill skill) => SkillRepo.Delete(skill);

        public void Update(Skill skill) => SkillRepo.Update(skill);


        public IEnumerable<SkillLevel> GetSkillLevels() => SkillLevelRepo.Get();

        public void Add(SkillLevel skillLevel) => SkillLevelRepo.Add(skillLevel);

        public void Delete(SkillLevel skillLevel) => SkillLevelRepo.Delete(skillLevel);

        public void Update(SkillLevel skillLevel) => SkillLevelRepo.Update(skillLevel);


        public IEnumerable<User> GetUsers() => UserRepo.Get();

        public void Add(User user) => UserRepo.Add(user);

        public void Delete(User user) => UserRepo.Delete(user);

        public void Update(User user) => UserRepo.Update(user);


        public IEnumerable<UserSkill> GetUserSkills() => UserSkillRepo.Get();

        public void Add(UserSkill userSkill) => UserSkillRepo.Add(userSkill);

        public void Delete(UserSkill userSkill) => UserSkillRepo.Delete(userSkill);

        public void Update(UserSkill userSkill) => UserSkillRepo.Update(userSkill);
    }
}
