using ServiceLayer.Models;
using System.Collections.Generic;

namespace ServiceLayer.Interfaces
{
    public interface IService
    {
        IEnumerable<ServiceSkill> GetSkills();
        IEnumerable<ServiceUser> GetUsers();
        void Add(ServiceUser user);
        void DeleteUser(int id);
        void Update(ServiceUser user);

    }
}
