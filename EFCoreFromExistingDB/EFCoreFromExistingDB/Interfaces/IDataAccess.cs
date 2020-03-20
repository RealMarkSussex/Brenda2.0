using EFCoreFromExistingDB.Models;
using System.Collections.Generic;

namespace EFCoreFromExistingDB.Interfaces
{
    public interface IDataAccess
    {
        IEnumerable<Level> GetLevels();
        void Add(Level level);
        void Delete(Level level);
        void Update(Level level);


        IEnumerable<Role> GetRoles();
        void Add(Role role);
        void Delete(Role role);
        void Update(Role role);


        IEnumerable<Skill> GetSkills();
        void Add(Skill skill);
        void Delete(Skill skill);
        void Update(Skill skill);


        IEnumerable<SkillLevel> GetSkillLevels();
        void Add(SkillLevel skillLevel);
        void Delete(SkillLevel skillLevel);
        void Update(SkillLevel skillLevel);


        IEnumerable<User> GetUsers();
        void Add(User user);
        void Delete(User user);
        void Update(User user);


        IEnumerable<UserSkill> GeUserSkills();
        void Add(UserSkill userSkill);
        void Delete(UserSkill userSkill);
        void Update(UserSkill userSkill);
    }
}
