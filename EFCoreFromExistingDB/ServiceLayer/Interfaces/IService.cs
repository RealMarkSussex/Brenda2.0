using ServiceLayer.Models;
using System.Collections.Generic;

namespace ServiceLayer.Interfaces
{
    public interface IService
    {
        IEnumerable<ServiceSkill> GetSkills();
        void DeleteSkill(int id);
        void Add(ServiceSkill skill);
        IEnumerable<ServiceUser> GetUsers();
        void Add(ServiceUser user);
        void DeleteUser(int id);
        void Update(ServiceUser user);
        IEnumerable<ServiceRole> GetRoles();
        IEnumerable<ServiceLevel> GetLevels();
        IEnumerable<ServiceSkillLevel> GetSkillLevels();

    }
}
