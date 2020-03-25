using EFCoreFromExistingDB.Models;
using System.Collections.Generic;

namespace EFCoreFromExistingDB.Interfaces
{
    public interface IDataAccess
    {
        IEnumerable<Level> GetLevels();
        void Add(Level level);
        void DeleteLevel(int id);
        void Update(Level level);


        IEnumerable<Role> GetRoles();
        void Add(Role role);
        void DeleteRole(int id);
        void Update(Role role);


        IEnumerable<Skill> GetSkills();
        void Add(Skill skill);
        void DeleteSkill(int id);
        void Update(Skill skill);


        IEnumerable<SkillLevel> GetSkillLevels();
        void Add(SkillLevel skillLevel);
        void DeleteSkillLevel(int id);
        void Update(SkillLevel skillLevel);


        IEnumerable<User> GetUsers();
        void Add(User user);
        void DeleteUser(int id);
        void Update(User user);


        IEnumerable<UserSkill> GetUserSkills();
        void Add(UserSkill userSkill);
        void DeleteUserSkill(int id);
        void Update(UserSkill userSkill);
    }
}
